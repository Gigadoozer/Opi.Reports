using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Opi.Reports.Application.DTOs;
using Opi.Reports.Application.Interfaces;

namespace Opi.Reports.Application.Features.Reports.Queries.GetAllReports
{
    public class GetAllReportsQueryHandler : IRequestHandler<GetAllReportsQuery, IEnumerable<ReportRecordDto>>
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;

        public GetAllReportsQueryHandler(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReportRecordDto>> Handle(GetAllReportsQuery request, CancellationToken cancellationToken)
        {
            var reports = await _repository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ReportRecordDto>>(reports);
        }
    }
}

