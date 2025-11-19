using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Opi.Reports.Application.DTOs;

namespace Opi.Reports.Application.Features.Reports.Queries.GetReportById
{
    public class GetReportByIdQuery : IRequest<ReportRecordDto>
    {
        public int Id { get; set; }

        public GetReportByIdQuery(int id)
        {
            Id = id;
        }
    }
}
