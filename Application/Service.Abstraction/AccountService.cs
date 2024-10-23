using Application.Common;
using Application.IService.Abstraction;
using Application.IService.Common;
using Application.Model.AccountModel;
using Application.Util;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly ISendMailService _sendMailService;
        private readonly IMemoryCache _memoryCache;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper,
            AppConfiguration appConfiguration, ICurrentTime currentTime,
            IClaimService claimService, IUploadImageService uploadImageService, ISendMailService sendMailService,IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appConfiguration = appConfiguration;
            _currentTime = currentTime;
            _claimsService = claimService;
            _uploadImageService = uploadImageService;
            _sendMailService = sendMailService;
            _memoryCache = memoryCache;
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

        public async Task<bool> ChangePasswordForForgetPasswordAsync(string code, ChangePasswordModel changePasswordModel)
        {
           if(changePasswordModel.ConfirmPassword!=changePasswordModel.Password)
            {
                throw new Exception("Confirm password and password must be the same");
            }
            var email = _memoryCache.Get<string>(code);
            var user = await _unitOfWork.AccountRepository.FindAccountByEmail(email);
            if (user != null)
            {
                if (changePasswordModel.Password.CheckPassword(user.PasswordHash))
                {
                    throw new Exception("New password must not be the same as old password");
                }
                user.PasswordHash = changePasswordModel.Password.Hash();
                _unitOfWork.AccountRepository.Update(user);
                _memoryCache.Remove(code);
            }
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> CreateStaffAccount(RegisterModel model)
        {
            var findUser = await _unitOfWork.AccountRepository.FindAccountByEmail(model.Email);
            if (findUser != null)
            {
                throw new Exception("Email already exist");
            }
            var newStaffAccount = _mapper.Map<Account>(model);
            newStaffAccount.PasswordHash = model.Password.Hash();
            newStaffAccount.RoleId = 2;
            await _unitOfWork.AccountRepository.AddAsync(newStaffAccount);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> CreateVetAccount(RegisterModel model)
        {
            var findUser = await _unitOfWork.AccountRepository.FindAccountByEmail(model.Email);
            if (findUser != null)
            {
                throw new Exception("Email already exist");
            }
            var newVetAccount = _mapper.Map<Account>(model);
            newVetAccount.PasswordHash = model.Password.Hash();
            newVetAccount.RoleId = 3;
            await _unitOfWork.AccountRepository.AddAsync(newVetAccount);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<AccountAmount> CustomerAccountAmount()
        {
            var amount = await _unitOfWork.AccountRepository.CustomerAccountAmount();
            var amountModel = new AccountAmount()
            {
                Amount = amount
            };
            return amountModel;
        }

        public async Task<AccountDetailViewModel> GetAccountDetailAsync(Guid accountId)
        {
            return await _unitOfWork.AccountRepository.GetAccountDetail(accountId);
        }

        public async Task<List<ListUserViewModel>> GetAllUserInSystemAsync()
        {
            var listAccount = await _unitOfWork.AccountRepository.GetAllAccountsForAdmin();
            var listAccountModel = listAccount.Select(x => new ListUserViewModel
            {
                AccountId = x.Id,
                ContactLink = x.ContactLink,
                Email = x.Email,
                Location = x.Location,
                Role = x.Role.RoleName,
                Username = x.Username,
                Status = x.IsDelete ? "Ban" : "Not ban"
            }).ToList();
            return listAccountModel;
        }

        public async Task<List<ListUserViewModel>> GetAllVeterinaryForAppointment()
        {
            var listAccount = await _unitOfWork.AccountRepository.GetAllVeterinaryAccountsForAppointment();
            var listAccountModel = listAccount.Select(x => new ListUserViewModel
            {
                AccountId = x.Id,
                ProfileImage = x.ProfileImage,
                ContactLink = x.ContactLink,
                Email = x.Email,
                Location = x.Location,
                Role = x.Role.RoleName,
                Username = x.Username,
                Status = x.IsDelete ? "Ban" : "Not ban"
            }).ToList();
            return listAccountModel;
        }

        public async Task<List<ListUserViewModel>> GetAllVeterinaryInSystemAsync()
        {
            var listAccount = await _unitOfWork.AccountRepository.GetAllVeterinaryAccounts();
            var listAccountModel = listAccount.Select(x => new ListUserViewModel
            {
                AccountId = x.Id,
                ProfileImage=x.ProfileImage,
                ContactLink = x.ContactLink,
                Email = x.Email,
                Location = x.Location,
                Role = x.Role.RoleName,
                Username = x.Username,
                Status = x.IsDelete ? "Ban" : "Not ban"
            }).ToList();
            return listAccountModel;
        }

        public async Task<CurrentUserModel> GetCurrentLoginUserAsync()
        {
            var loginUser = await _unitOfWork.AccountRepository.GetByIdAsync(_claimsService.GetCurrentUserId, x => x.Role);
            var currentUser = new CurrentUserModel
            {
                AccountId = loginUser.Id,
                Email = loginUser.Email,
                Role = loginUser.Role.RoleName,
                Username = loginUser.Username,
                Location = loginUser.Location,
                ContactLink = loginUser.ContactLink,
                Fullname=loginUser.Fullname,
                Phonenumber=loginUser.Phonenumber,
                ProfileImage=loginUser.ProfileImage
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
            if (findUser.IsDelete == true)
            {
                throw new Exception("You have been banned");
            }
            var accessToken = findUser.GenerateTokenString(_appConfiguration!.JwtSecretKey, _currentTime.GetCurrentTime());
            var refreshToken = RefreshToken.GetRefreshToken();
            return new Token
            {
                userId = findUser.Id,
                accessToken = accessToken,
                refreshToken = refreshToken,
                userName = findUser.Username
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
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel)
        {
            var user = await _unitOfWork.AccountRepository.GetByIdAsync(_claimsService.GetCurrentUserId);
            if (user != null)
            {
                if (!resetPasswordModel.OldPassword.CheckPassword(user.PasswordHash))
                {
                    throw new Exception("Password incorrect");
                }
                if(resetPasswordModel.OldPassword==resetPasswordModel.NewPassword)
                {
                    throw new Exception("New password must not be the same as old password");
                }
                user.PasswordHash = resetPasswordModel.NewPassword.Hash();
                _unitOfWork.AccountRepository.Update(user);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }
            else
            {
                throw new Exception("Account has been banned");
            }
        }

        public async Task<bool> SendVerificationCodeToEmail(string email)
        {
            var findAccount = await _unitOfWork.AccountRepository.FindAccountByEmail(email);
            string key;
            if (findAccount == null)
            {
                throw new Exception("Account do not exist");
            }
            try
            {
                key = StringUtil.RandomString(6);
                //Get project's directory and fetch ForgotPasswordTemplate content from EmailTemplate
                string exePath = Environment.CurrentDirectory.ToString();
                string FilePath = exePath + @"/EmailTemplate/ForgotPassword.html";
                StreamReader streamreader = new StreamReader(FilePath);
                string MailText = streamreader.ReadToEnd();
                streamreader.Close();
                //Replace [resetpasswordkey] = key
                MailText = MailText.Replace("[resetpasswordkey]", key);
                //Replace [emailaddress] = email
                MailText = MailText.Replace("[emailaddress]", email);
                var result = await _sendMailService.SendMailAsync(email, "ResetPassword", MailText);
                if (!result)
                {
                    return false;
                };

                _memoryCache.Set(key, email, DateTimeOffset.Now.AddMinutes(10));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public async Task<AccountAmount> StaffAccountAmount()
        {
            var amount = await _unitOfWork.AccountRepository.StaffAccountAmount();
            var amountModel = new AccountAmount()
            {
                Amount = amount
            };
            return amountModel;
        }

        public async Task<bool> UnBanAccountAsync(Guid accountId)
        {
            var bannedAccount = await _unitOfWork.AccountRepository.GetBannedAccount(accountId);
            if (bannedAccount == null)
            {
                throw new Exception("This account is not banned");
            }
            bannedAccount.IsDelete = false;
            _unitOfWork.AccountRepository.Update(bannedAccount);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UpdateProfileAsync(UpdateAccount updateAccount)
        {
            var loginUser = await _unitOfWork.AccountRepository.GetByIdAsync(_claimsService.GetCurrentUserId);
            if(loginUser == null)
            {
                throw new Exception("Account do not exist");
            }
            _mapper.Map(updateAccount, loginUser,typeof(UpdateAccount),typeof(Account));
            _unitOfWork.AccountRepository.Update(loginUser);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<bool> UploadImageForAccount(IFormFile formFile)
        {
            var updateAccount = await _unitOfWork.AccountRepository.GetByIdAsync(_claimsService.GetCurrentUserId);
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
            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        public async  Task<AccountAmount> VeterinaryAccountAmount()
        {
            var amount = await _unitOfWork.AccountRepository.VeterinaryAccountAmount();
            var amountModel = new AccountAmount()
            {
                Amount = amount
            };
            return amountModel;
        }
    }
}
