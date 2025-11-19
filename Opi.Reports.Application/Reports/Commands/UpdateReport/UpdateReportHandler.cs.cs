using AutoMapper;
using MediatR;
using Opi.Reports.Application.Interfaces;
using Opi.Reports.Application.Reports.Commands.UpdateReport;
using Opi.Reports.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opi.Reports.Application.Features.Reports.Commands.UpdateReport
{
    public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand, bool>
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;

        public UpdateReportCommandHandler(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            var report = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (report == null)
                return false;

            _mapper.Map(request, report);

            await _repository.UpdateAsync(report, cancellationToken);

            return true;
        }
    }
}
