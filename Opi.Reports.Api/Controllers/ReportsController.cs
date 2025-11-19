using MediatR;
using Microsoft.AspNetCore.Mvc;
using Opi.Reports.Application.DTOs;
using Opi.Reports.Application.Features.Reports.Commands.CreateReport;
using Opi.Reports.Application.Features.Reports.Queries.GetAllReports;
using Opi.Reports.Application.Features.Reports.Queries.GetReportById;
using Opi.Reports.Application.Interfaces;
using Opi.Reports.Application.Reports.Commands.DeleteReport;
using Opi.Reports.Application.Reports.Commands.UpdateReport;

namespace Opi.Reports.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IReportPdfService _pdfService;

        public ReportController(IMediator mediator, IReportPdfService pdfService)
        {
            _mediator = mediator;
            _pdfService = pdfService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReportCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetReportByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllReportsQuery());
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReportCommand command)
        {
            command.Id = id;
            var success = await _mediator.Send(command);
            if (!success) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _mediator.Send(new DeleteReportCommand(id));
            if (!success) return NotFound();
            return Ok();
        }

        // PDF
        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GetPdf(int id)
        {
            var reportRecord = await _mediator.Send(new GetReportByIdQuery(id));
            if (reportRecord == null) return NotFound();

            var row = new ReportRowDto
            {
                AsignadoA = reportRecord.AsignadoA ?? "",
                Rol = reportRecord.Rol ?? "",
                Proyecto = reportRecord.Proyecto ?? "",
                FechaReporte = reportRecord.FechaReporte,
                Descripcion = reportRecord.Description ?? "",
                HorasPlaneadas = reportRecord.HorasPlaneadas,
                HorasReales = reportRecord.HorasReales
            };

            var pdfBytes = _pdfService.GeneratePdf(new[] { row });
            return File(pdfBytes, "application/pdf", $"OPIReport_{id}.pdf");
        }
    }
}
