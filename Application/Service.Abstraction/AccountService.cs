using Application.Common;
using Application.IService.Abstraction;
using Application.IService.Common;
using Application.Model.AccountModel;
using Application.Util;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly AppConfiguration _appConfiguration;
        private readonly ICurrentTime _currentTime;
        private readonly IClaimService _claimsService;
        private readonly IUploadImageService _uploadImageService;
        public AccountService(IUnitOfWork unitOfWork,IMapper mapper,
            AppConfiguration appConfiguration,ICurrentTime currentTime,
            IClaimService claimService,IUploadImageService uploadImageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appConfiguration = appConfiguration;
            _currentTime = currentTime;
            _claimsService = claimService;
            _uploadImageService = uploadImageService;
        }

        public async Task<bool> BanAccountAsync(Guid accountId)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(accountId);
            if (account == null)
            {
                throw new Exception("Account already been banned");
            }
            _unitOfWork.AccountRepository.SoftRemove(account);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> CreateStaffAccount(RegisterModel model)
        {
            var findUser = await _unitOfWork.AccountRepository.FindAccountByEmail(model.Email);
            if (findUser != null)
            {
                throw new Exception("Email already exist");
            }
            var newStaffAccount=_mapper.Map<Account>(model);
            newStaffAccount.PasswordHash = model.Password.Hash();
            newStaffAccount.RoleId = 2;
            await _unitOfWork.AccountRepository.AddAsync(newStaffAccount);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<bool> CreateVetAccount(RegisterModel model)
        {
            var findUser = await _unitOfWork.AccountRepository.FindAccountByEmail(model.Email);
            if (findUser != null)
            {
                throw new Exception("Email already exist");
            }
            var newVetAccount=_mapper.Map<Account>(model);
            newVetAccount.PasswordHash = model.Password.Hash();
            newVetAccount.RoleId = 3;
            await _unitOfWork.AccountRepository.AddAsync(newVetAccount);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<List<ListUserViewModel>> GetAllUserInSystemAsync()
        {
            var listAccount = await _unitOfWork.AccountRepository.GetAllAccountsForAdmin();
            var listAccountModel = listAccount.Select(x => new ListUserViewModel
            {
                 AccountId=x.Id,
                 ContactLink=x.ContactLink,
                 Email=x.Email,
                 Location=x.Location,
                 Role=x.Role.RoleName,
                 Username=x.Username,
                 Status=x.IsDelete?"Ban":"Not ban"
            }).ToList();
            return listAccountModel;
        }

        public async Task<CurrentUserModel> GetCurrentLoginUserAsync()
        {
            var loginUser = await _unitOfWork.AccountRepository.GetByIdAsync(_claimsService.GetCurrentUserId, x => x.Role);
            var currentUser = new CurrentUserModel
            {
                AccountId=loginUser.Id,
                Email=loginUser.Email,
                Role=loginUser.Role.RoleName,
                Username=loginUser.Username,
                Location=loginUser.Location,
                ContactLink=loginUser.ContactLink,
            };
            return currentUser;
        }

        public async Task<Token> LoginAsync(LoginModel loginModel)
        {
            var findUser = await _unitOfWork.AccountRepository.FindAccountByEmail(loginModel.Email);
            if (findUser == null)
            {
                throw new Exception("Account do not exist");
            }
            if (!loginModel.Password.CheckPassword(findUser.PasswordHash))
            {
                throw new Exception("Password incorrect");
            }
            var accessToken = findUser.GenerateTokenString(_appConfiguration!.JwtSecretKey, _currentTime.GetCurrentTime());
            var refreshToken = RefreshToken.GetRefreshToken();
            return new Token 
            { 
                userId=findUser.Id,
                accessToken=accessToken,
                refreshToken=refreshToken,
                userName=findUser.Username
            };
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            var findUser = await _unitOfWork.AccountRepository.FindAccountByEmail(model.Email);
            if (findUser != null)
            {
                throw new Exception("Email already exist");
            }
            var newAccount = _mapper.Map<Account>(model);
            newAccount.PasswordHash = StringUtil.Hash(model.Password);
            newAccount.RoleId = 4;
            await _unitOfWork.AccountRepository.AddAsync(newAccount);
            return await _unitOfWork.SaveChangeAsync()>0;
        }

        public async Task<bool> UnBanAccountAsync(Guid accountId)
        {
          var bannedAccount=await _unitOfWork.AccountRepository.GetBannedAccount(accountId);
            if (bannedAccount == null)
            {
                throw new Exception("This account is not banned");
            }
            bannedAccount.IsDelete= false;
            _unitOfWork.AccountRepository.Update(bannedAccount);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UploadImageForAccount(Guid accountId, IFormFile formFile)
        {
            var updateAccount=await _unitOfWork.AccountRepository.GetByIdAsync(accountId);
            if (updateAccount != null)
            {
                string uploadImage = await _uploadImageService.UploadFileToFireBase(formFile, "Account");
                updateAccount.ProfileImage = uploadImage;
                _unitOfWork.AccountRepository.Update(updateAccount);
            }
            else
            {
                throw new Exception("Account do not exist");
            }
          return  await _unitOfWork.SaveChangeAsync()>0;
        }
    }
}
