using Opi.Reports.Application.DTOs;
using Opi.Reports.Infrastructure.Pdf;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Opi.Reports.Application.Interfaces;

namespace Opi.Reports.Infrastructure.Pdf
{
    public class PdfReportService : IReportPdfService
    {
        public byte[] GeneratePdf(IEnumerable<ReportRowDto> rows)
        {
            var doc = new ReportDocument(rows);
            using var ms = new MemoryStream();
            doc.GeneratePdf(ms);
            return ms.ToArray();
        }
    }
}
