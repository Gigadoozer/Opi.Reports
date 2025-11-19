using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Opi.Reports.Application.DTOs;
using Opi.Reports.Domain.Enums;


namespace Opi.Reports.Application.Features.Reports.Commands.CreateReport
{
    public class CreateReportCommand : IRequest<int>
    {
        public string ReportName { get; set; }
        public string Description { get; set; }
        public ReportStatus Status { get; set; }
        public DateTime FechaReporte { get; set; }
        public decimal HorasPlaneadas { get; set; }
        public decimal HorasReales { get; set; }
    }
}

