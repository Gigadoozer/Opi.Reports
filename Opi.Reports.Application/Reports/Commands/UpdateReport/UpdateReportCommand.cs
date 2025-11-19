using MediatR;
using Opi.Reports.Domain.Enums;

namespace Opi.Reports.Application.Reports.Commands.UpdateReport
{
    public class UpdateReportCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string ReportName { get; set; }
        public string? Description { get; set; }
        public ReportStatus Status { get; set; }
        public DateTime FechaReporte { get; set; }
        public decimal HorasPlaneadas { get; set; }
        public decimal HorasReales { get; set; }
    }
}
