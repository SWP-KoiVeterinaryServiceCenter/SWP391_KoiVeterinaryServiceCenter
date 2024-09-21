using Application.Common;
using Application.IService.Abstraction;
using Application.IService.Common;
using Application.Model.AccountModel;
using Application.Util;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public AccountService(IUnitOfWork unitOfWork,IMapper mapper,AppConfiguration appConfiguration,ICurrentTime currentTime,IClaimService claimService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appConfiguration = appConfiguration;
            _currentTime = currentTime;
            _claimsService = claimService;
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
    }
}
