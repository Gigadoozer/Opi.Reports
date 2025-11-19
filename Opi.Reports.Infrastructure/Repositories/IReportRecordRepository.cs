using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opi.Reports.Domain.Entities;

namespace Opi.Reports.Infrastructure.Repositories
{
    public interface IReportRecordRepository
    {
        Task<ReportRecord> AddAsync(ReportRecord entity);
        Task<ReportRecord?> GetByIdAsync(int id);
        Task<IEnumerable<ReportRecord>> GetAllAsync();
        Task UpdateAsync(ReportRecord entity);
        Task DeleteAsync(int id);
    }
}
