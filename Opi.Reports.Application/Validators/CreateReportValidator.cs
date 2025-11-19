using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Opi.Reports.Application.Features.Reports.Commands.CreateReport;

namespace Opi.Reports.Application.Validators
{
    public class CreateReportValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportValidator()
        {
            RuleFor(x => x.ReportName)
                .NotEmpty().WithMessage("El nombre del reporte es obligatorio.")
                .MinimumLength(3).WithMessage("El nombre debe tener mínimo 3 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("El estado no es válido.");

            RuleFor(x => x.FechaReporte)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de reporte no puede ser futura.");

            RuleFor(x => x.HorasPlaneadas)
                .GreaterThanOrEqualTo(0).WithMessage("Las horas planeadas no pueden ser negativas.");

            RuleFor(x => x.HorasReales)
                .GreaterThanOrEqualTo(0).WithMessage("Las horas reales no pueden ser negativas.");
        }
    }
}

