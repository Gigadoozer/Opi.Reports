using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opi.Reports.Domain.Enums;

namespace Opi.Reports.Application.DTOs
{
    public class ReportRecordDto
    {
        public int Id { get; set; }
        public required string ReportName { get; set; }
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }
        public ReportStatus Status { get; set; }


        public string? AsignadoA { get; set; }
        public string? Rol { get; set; }
        public string? Proyecto { get; set; }

        public DateTime FechaReporte { get; set; }

        public int HorasPlaneadas { get; set; }
        public int HorasReales { get; set; }
    }
}
