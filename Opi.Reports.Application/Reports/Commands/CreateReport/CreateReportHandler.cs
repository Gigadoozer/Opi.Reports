using AutoMapper;
using MediatR;
using Opi.Reports.Application.DTOs;
using Opi.Reports.Application.Interfaces;
using Opi.Reports.Domain.Entities;
using Opi.Reports.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opi.Reports.Application.Features.Reports.Commands.CreateReport
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, int>
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;

        public CreateReportCommandHandler(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ReportRecord>(request);

            await _repository.AddAsync(entity, cancellationToken);

            return entity.Id;
        }
    }
}
