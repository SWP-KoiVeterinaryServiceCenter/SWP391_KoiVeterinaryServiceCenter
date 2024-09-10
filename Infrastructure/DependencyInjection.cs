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
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(databaseConnection).EnableSensitiveDataLogging());
            return services;
        }
    }
}
