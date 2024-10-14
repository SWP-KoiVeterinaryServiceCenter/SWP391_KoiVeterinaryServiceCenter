using Application.IService.Abstraction;
using Application.IService.Common;
using Application.VnPay.Config;
using Application.VnPay.Lib;
using Application.VnPay.Request;
using Application.VnPay.Response;
using Domain.Enum;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Abstraction
{
    public class PaymentService : IPaymentService
    {
        private VnPayConfig vnpayConfig;
        private readonly ICurrentUserIp _currentUserIp;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(IOptions<VnPayConfig> vnpayConfig, ICurrentUserIp currentUserIp, IUnitOfWork unitOfWork)
        {
            this.vnpayConfig = vnpayConfig.Value;
            _currentUserIp = currentUserIp;
            _unitOfWork = unitOfWork;
        }
        public string GetPaymentUrl(Guid appointmentId, decimal amount)
        {
            string orderId = appointmentId.ToString() + "_" + "Payment";
            var vnpayRequest = new VnPayRequest(vnpayConfig.Version,
                       vnpayConfig.TmnCode, DateTime.UtcNow,
                       _currentUserIp.UserIp, amount, "VND", "other", "Nap tien vao vi", vnpayConfig.ReturnUrl, orderId);
            string paymentUrl = vnpayRequest.GetLink(vnpayConfig.PaymentUrl, vnpayConfig.HashSecret);
            if (paymentUrl == null)
            {
                throw new Exception("Error when generate payment link");
            }
            return paymentUrl;
        }

        public async Task<bool> HandleVnpayResponseAsync(VnPayResponse response)
        {
            bool isUpdated = false;
            var orderId = response.vnp_TxnRef;
            string[] parts = orderId.Split('_');
            string appointmentId = parts[0];
            var vnpSecureHash = response.vnp_SecureHash;
            bool checkValid = response.IsValidSignature(vnpayConfig.HashSecret);
            if (checkValid)
            {
                if (response.vnp_ResponseCode != "00")
                {
                    isUpdated = false;
                }
                else
                {
                    Guid appointId = Guid.Parse(appointmentId);
                    var appointment = await _unitOfWork.AppointmentRepository.GetByIdAsync(appointId);
                    if (appointment == null)
                    {
                        throw new Exception("Appointment not found");
                    }
                    appointment.AppointmentStatus = nameof(AppointmentStatus.Confirmed);
                    _unitOfWork.AppointmentRepository.Update(appointment);

                }
            }
            else
            {
                throw new Exception("Has invalid secretkey");

            }
            if (await _unitOfWork.SaveChangeAsync() > 0)
            {
                isUpdated = true;
                return isUpdated;
            }
            else
            {
                isUpdated = false;
                return isUpdated;
            }

        }
    }
}
