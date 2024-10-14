using Application.VnPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService.Abstraction
{
    public interface IPaymentService
    {
         string GetPaymentUrl(Guid appointmentId, decimal amount);
        Task<bool> HandleVnpayResponseAsync(VnPayResponse response);
    }
}
