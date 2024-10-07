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
        [HttpPatch("{accountId}")]
        public async Task<IActionResult> UploadProfileImage(Guid accountId,IFormFile formFile)
        {
            var uploadImage=await _accountService.UploadImageForAccount(accountId,formFile);
            if (uploadImage)
            {
                return Ok(uploadImage);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> CustomerAmount()
        {
            var customerAmount = await _accountService.CustomerAccountAmount();
            return Ok(customerAmount);
        }
        [HttpGet]
        public async Task<IActionResult> VetAmount()
        {
            var verterinaryAmount=await _accountService.VeterinaryAccountAmount();
            return Ok(verterinaryAmount);
        }
        [HttpGet]
        public async Task<IActionResult> StaffAmount()
        {
            var staffAmount=await _accountService.StaffAccountAmount();
            return Ok(staffAmount);
        }
        [HttpGet]
        public async Task<IActionResult> SendVerifcationCode(string email)
        {
            var isCorret=await _accountService.SendVerificationCodeToEmail(email);
            if (isCorret)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("{code}")]
        public async Task<IActionResult> ChangePasswordForForgetPassword(string code,ChangePasswordModel model)
        {
            var isChange=await _accountService.ChangePasswordForForgetPasswordAsync(code,model);
            if (isChange)
            {
                return Ok();
            }
            return BadRequest();
        }
        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var isReset=await _accountService.ResetPasswordAsync(model);
            if (isReset)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
