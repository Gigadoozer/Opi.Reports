using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opi.Reports.Domain.Entities;

namespace Opi.Reports.Infrastructure.Repositories
{
    public class ReportRecordRepository : IReportRecordRepository
    {
        private readonly List<ReportRecord> _reports = new();
        private int _nextId = 1;

        public Task<ReportRecord> AddAsync(ReportRecord entity)
        {
            entity.Id = _nextId++;
            _reports.Add(entity);
            return Task.FromResult(entity);
        }

        public Task<ReportRecord?> GetByIdAsync(int id)
        {
            var report = _reports.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(report);
        }

        public Task<IEnumerable<ReportRecord>> GetAllAsync()
        {
            return Task.FromResult(_reports.AsEnumerable());
        }

        public Task UpdateAsync(ReportRecord entity)
        {
            var existing = _reports.FirstOrDefault(r => r.Id == entity.Id);
            if (existing != null)
            {
                existing.ReportName = entity.ReportName;
                existing.Description = entity.Description;
                existing.Status = entity.Status;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var report = _reports.FirstOrDefault(r => r.Id == id);
            if (report != null)
                _reports.Remove(report);

            return Task.CompletedTask;
        }
    }
}
