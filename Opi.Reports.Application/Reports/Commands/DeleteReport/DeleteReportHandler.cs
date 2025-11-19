using MediatR;
using Opi.Reports.Application.Interfaces;
using Opi.Reports.Application.Reports.Commands.DeleteReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opi.Reports.Application.Features.Reports.Commands.DeleteReport
{
    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand, bool>
    {
        private readonly IReportRepository _repository;

        public DeleteReportCommandHandler(IReportRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (report == null)
                return false;

            await _repository.DeleteAsync(request.Id, cancellationToken);

            return true;
        }
    }
}
