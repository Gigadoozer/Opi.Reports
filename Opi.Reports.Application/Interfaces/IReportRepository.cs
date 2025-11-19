using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opi.Reports.Domain.Entities;

namespace Opi.Reports.Application.Interfaces
{
    public interface IReportRepository
    {
        Task<ReportRecord?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<ReportRecord>> GetAllAsync(CancellationToken cancellationToken);
        Task AddAsync(ReportRecord report, CancellationToken cancellationToken);
        Task UpdateAsync(ReportRecord report, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
