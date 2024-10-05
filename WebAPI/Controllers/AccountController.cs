using Application.IService.Abstraction;
using Application.Model.AccountModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var token=await _accountService.LoginAsync(model);
            if (token == null)
            {
                return BadRequest();
            }
            return Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model) 
        { 
            bool isRegister=await _accountService.RegisterAsync(model);
            if (isRegister)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCurrentLoginUser()
        {
            var currentUser=await _accountService.GetCurrentLoginUserAsync();
            if(currentUser == null)
            {
                return BadRequest();
            }
            return Ok(currentUser);
        }
        [Authorize(Roles ="Admin,Staff")]
        [HttpPost]
        public async Task<IActionResult> CreateVetAccount(RegisterModel registerModel)
        {
            bool isRegister = await _accountService.CreateVetAccount(registerModel);
            if (isRegister)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        public async Task<IActionResult> CreateStaffAccount(RegisterModel registerModel)
        {
            bool isRegister = await _accountService.CreateStaffAccount(registerModel);
            if (isRegister)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> BanAccount(Guid accountId)
        {
            bool isBanned=await _accountService.BanAccountAsync(accountId);
            if (isBanned)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPatch("{accountId}")]
        public async Task<IActionResult> UnBanAccount(Guid accountId)
        {
            bool isBanned = await _accountService.UnBanAccountAsync(accountId);
            if (isBanned)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Accounts()
        {
            var listUser=await _accountService.GetAllUserInSystemAsync();
            if(listUser.Count > 0)
            {
                return Ok(listUser);
            }
            return BadRequest();
        }
        [HttpGet("{accountId}")]
        public async Task<IActionResult> AccountDetail(Guid accountId)
        {
            var accountDetail=await _accountService.GetAccountDetailAsync(accountId);
            if (accountDetail != null)
            {
                return Ok(accountDetail);
            }
            return BadRequest();
        }
    }
}
