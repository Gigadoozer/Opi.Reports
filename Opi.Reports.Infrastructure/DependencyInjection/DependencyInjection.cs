using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Opi.Reports.Infrastructure.Repositories;
using Opi.Reports.Infrastructure.Persistence;
using Opi.Reports.Application.Interfaces;
using Opi.Reports.Infrastructure.Pdf;



namespace Opi.Reports.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ReportDbContext>(options =>
            {
                options.UseInMemoryDatabase("ReportDb");
            });

            services.AddScoped<IReportPdfService, PdfReportService>();
            return services;
        }
    }
}
