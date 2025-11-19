using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opi.Reports.Application.Interfaces;
using Opi.Reports.Infrastructure.Persistence;
using Opi.Reports.Infrastructure.Repositories;

namespace Opi.Reports.Infrastructure.DI
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<ReportDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IReportRepository, Repositories.ReportRepository>();

            return services;
        }
    }
}
