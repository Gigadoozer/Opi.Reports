using Opi.Reports.Application.DTOs;
using Opi.Reports.Application.Interfaces;
using Opi.Reports.Domain.Entities;
using Opi.Reports.Infrastructure.Documents;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opi.Reports.Infrastructure.Services
{
    public class ReportPdfService : IReportPdfService
    {
        public byte[] GeneratePdf(ReporteGeneral reporte)
        {
            var doc = new ReportDocument(reporte);
            using var ms = new MemoryStream();
            doc.GeneratePdf(ms);
            return ms.ToArray();
        }

        public byte[] GeneratePdf(IEnumerable<ReportRowDto> rows)
        {
            throw new NotImplementedException();
        }
    }
}
