using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Opi.Reports.Application.DTOs;

namespace Opi.Reports.Application.Features.Reports.Queries.GetAllReports
{
    public class GetAllReportsQuery : IRequest<List<ReportRecordDto>>
    {
    }
}
