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
    }
}
