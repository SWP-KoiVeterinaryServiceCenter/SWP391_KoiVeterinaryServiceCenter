﻿using Application.Model.AccountModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterModel model);
        Task<Token> LoginAsync(LoginModel loginModel);
        Task<CurrentUserModel> GetCurrentLoginUserAsync();
        Task<bool> CreateVetAccount(RegisterModel model);
        Task<bool> CreateStaffAccount(RegisterModel model);
        Task<bool> UploadImageForAccount(IFormFile formFile);
        Task<List<ListUserViewModel>> GetAllUserInSystemAsync();
        Task<bool> BanAccountAsync(Guid accountId);
        Task<bool> UnBanAccountAsync(Guid accountId);
        Task<AccountDetailViewModel> GetAccountDetailAsync(Guid accountId);
        Task<AccountAmount> VeterinaryAccountAmount();
        Task<AccountAmount> StaffAccountAmount();
        Task<AccountAmount> CustomerAccountAmount();
        Task<bool> SendVerificationCodeToEmail(string email);
        Task<bool> ChangePasswordForForgetPasswordAsync(string code,ChangePasswordModel changePasswordModel);
        Task<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
        Task<List<ListUserViewModel>> GetAllVeterinaryInSystemAsync();
        Task<bool> UpdateProfileAsync(UpdateAccount updateAccount);
    }
}
