using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Opi.Reports.Domain.Entities;

namespace Opi.Reports.Infrastructure.Documents
{
    public class ReportDocument : IDocument
    {
        private readonly ReporteGeneral _reporte;

        public ReportDocument(ReporteGeneral reporte) => _reporte = reporte;

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Height(60).Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text(_reporte.Titulo).FontSize(14).SemiBold();
                        col.Item().Text(_reporte.Periodo).FontSize(10);
                    });
                    row.ConstantItem(150).AlignRight().Text($"Generado: {DateTime.Now:yyyy-MM-dd}").FontSize(9);
                });

                page.Content().PaddingTop(10).Element(ComposeTable);

                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("OPI Reports").FontSize(9);
                    text.Span("\n");  // Esto reemplaza LineBreak()
                    text.Span("Página ").FontSize(9);
                    text.CurrentPageNumber();
                    text.Span(" de ").FontSize(9);
                    text.TotalPages();
                });
            });
        }

        void ComposeTable(IContainer container)
        {
            container.Table(table =>
            {
                // Ajusta columnas para imitar el PDF
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(90);   // AsignadoA
                    columns.ConstantColumn(70);   // Rol
                    columns.ConstantColumn(120);  // Proyecto
                    columns.ConstantColumn(70);   // Fecha
                    columns.RelativeColumn(2);    // Descripcion
                    columns.ConstantColumn(70);   // HorasPlaneadas
                    columns.ConstantColumn(70);   // HorasReales
                });

                // Header (se repetirá en nueva página por QuestPDF)
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("Asignado a").SemiBold();
                    header.Cell().Element(CellStyle).Text("Rol").SemiBold();
                    header.Cell().Element(CellStyle).Text("Proyectos").SemiBold();
                    header.Cell().Element(CellStyle).Text("Fecha Reporte").SemiBold();
                    header.Cell().Element(CellStyle).Text("Descripción").SemiBold();
                    header.Cell().Element(CellStyle).Text("Horas Planeadas").SemiBold().AlignRight();
                    header.Cell().Element(CellStyle).Text("Horas Reales").SemiBold().AlignRight();
                });

                // Data
                if (_reporte.Filas != null)
                {
                    foreach (var fila in _reporte.Filas)
                    {
                        table.Cell().Element(CellStyle).Text(fila.AsignadoA ?? "");
                        table.Cell().Element(CellStyle).Text(fila.Rol ?? "");
                        table.Cell().Element(CellStyle).Text(fila.Proyecto ?? "");
                        table.Cell().Element(CellStyle).Text(fila.FechaReporte.ToString("yyyy-MM-dd"));
                        table.Cell().Element(CellStyle).Text(fila.Descripcion ?? "").WrapAnywhere();
                        table.Cell().Element(CellStyle).AlignRight().Text(FormatDecimal(fila.HorasPlaneadas));
                        table.Cell().Element(CellStyle).AlignRight().Text(FormatDecimal(fila.HorasReales));
                    }
                }

                static IContainer CellStyle(IContainer c) => c.Padding(6).Border(1).BorderColor(Colors.Grey.Lighten2);
            });
        }

        static string FormatDecimal(decimal d) => d.ToString("0.##");
    }
}
