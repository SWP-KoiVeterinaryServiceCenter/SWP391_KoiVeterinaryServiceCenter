using Application.IService.Abstraction;
using Application.IService.Common;
using Application.Service.Abstraction;
using Application.Service.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.WebService;

namespace WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services, string secretKey)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<ICurrentTime, CurrentTime>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IKoiService, KoiService>();
            services.AddScoped<ICenterTankService, CenterTankService>();
            services.AddScoped<IServiceTypeService, ServiceTypeService>();
            services.AddScoped<ICenterServiceService, CenterServiceService>();
            services.AddScoped<IWorkingScheduleService, WorkingScheduleService>();
            services.AddScoped<IAppointmentService, AppointmentService>();  
            services.AddScoped<IUploadImageService, UploadImageService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<IRatingService, RatingService>();
            services.AddScoped<ITravelExpenseService, TravelExpenseService>();
            services.AddScoped<ICurrentUserIp,CurrentUserIp>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IAccountScheduleService, AccountScheduleService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(12);
                options.Cookie.Name = "GoodExchange";
                options.Cookie.IsEssential = true;
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = secretKey,
                      ValidAudience = secretKey,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                      ClockSkew = TimeSpan.FromSeconds(1)
                  };
              });

            return services;
        }
    }
}
