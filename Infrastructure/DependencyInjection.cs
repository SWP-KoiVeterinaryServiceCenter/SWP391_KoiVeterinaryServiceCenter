using Application;
using Application.IRepository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfratructureService(this IServiceCollection services, string databaseConnection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(databaseConnection).EnableSensitiveDataLogging());
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IKoiRepository, KoiRepository>();
            services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();
            services.AddScoped<ICenterServiceRepository, CenterServiceRepository>();
            services.AddScoped<ICenterTankRepository, CenterTankRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            return services;
        }
    }
}
