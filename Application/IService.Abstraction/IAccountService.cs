﻿using Application.Model.AccountModel;
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
    }
}
