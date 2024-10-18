using Application.IService.Abstraction;
using Application.VnPay.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        public IActionResult GetPaymentUrl([FromQuery] Guid appointmentId, decimal amount)
        {
            string paymentUrl =_paymentService.GetPaymentUrl(appointmentId, amount);
            if(string.IsNullOrEmpty(paymentUrl))
            {
                return NotFound();
            }
            return Ok(paymentUrl);
        }
        [HttpGet]
        public async Task<IActionResult> VnPayRedirect([FromQuery] VnPayResponse vnPayResponse)
        {
            var isUpdated = await _paymentService.HandleVnpayResponseAsync(vnPayResponse);
            if (isUpdated)
            {
                /* string exePath = Environment.CurrentDirectory.ToString();
                 string FilePath = exePath + @"/PaymentTemplate/PaymentSuccessful.html";
                 var htmlContent = await System.IO.File.ReadAllTextAsync(FilePath);
                 return Content(htmlContent, "text/html");*/
                return Redirect("http://localhost:5173/customer/serviceInformation");
            }
            string evnPath = Environment.CurrentDirectory.ToString();
            string filePath = evnPath + @"/PaymentTemplate/PaymentFailed.html";
            var htmlFileContent = await System.IO.File.ReadAllTextAsync(filePath);
            return Content(htmlFileContent, "text/html");
        }
    }
}
