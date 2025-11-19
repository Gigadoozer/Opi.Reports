using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opi.Reports.Domain.Entities;
using Opi.Reports.Application.DTOs;

namespace Opi.Reports.Application.Interfaces
{
    public interface IReportPdfService
    {
        byte[] GeneratePdf(IEnumerable<ReportRowDto> rows);
    }
}
