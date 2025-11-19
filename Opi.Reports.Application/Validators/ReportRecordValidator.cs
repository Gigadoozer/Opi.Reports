using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Opi.Reports.Domain.Entities;

namespace Opi.Reports.Application.Validators
{
    public class ReportRecordValidator : AbstractValidator<ReportRecord>
    {
        public ReportRecordValidator()
        {
            RuleFor(x => x.ReportName)
                .NotEmpty().WithMessage("El nombre del reporte es obligatorio.")
                .MinimumLength(3);

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.FechaReporte)
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.HorasPlaneadas)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.HorasReales)
                .GreaterThanOrEqualTo(0);
        }
    }
}

