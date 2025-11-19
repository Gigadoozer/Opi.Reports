using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opi.Reports.Application.Interfaces;
using Opi.Reports.Domain.Entities;
using Opi.Reports.Infrastructure.Persistence;

namespace Opi.Reports.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ReportDbContext _context;

        public ReportRepository(ReportDbContext context)
        {
            _context = context;
        }

        public async Task<ReportRecord?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Reports
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<IEnumerable<ReportRecord>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Reports
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(ReportRecord report, CancellationToken cancellationToken)
        {
            await _context.Reports.AddAsync(report, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(ReportRecord report, CancellationToken cancellationToken)
        {
            _context.Reports.Update(report);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var report = await _context.Reports
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
