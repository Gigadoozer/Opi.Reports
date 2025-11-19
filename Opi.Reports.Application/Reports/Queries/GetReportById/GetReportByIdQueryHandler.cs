using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Opi.Reports.Application.DTOs;
using Opi.Reports.Application.Interfaces;

namespace Opi.Reports.Application.Features.Reports.Queries.GetReportById
{
    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ReportRecordDto>
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;

        public GetReportByIdQueryHandler(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReportRecordDto> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            var report = await _repository.GetByIdAsync(request.Id, cancellationToken);

            if (report == null)
                return null;

            return _mapper.Map<ReportRecordDto>(report);
        }
    }
}

