using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia.Data
{
    public static class PrzychodniaDbContextExtensions
    {
        public static IServiceCollection AddPrzychodniaContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PrzychodniaDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PrzychodniaDB")));

            return services;
        }
    }
}
