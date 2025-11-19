using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using Opi.Reports.Application.DTOs;
using System.Collections.Generic;
using System.IO;

namespace Opi.Reports.Infrastructure.Pdf
{
    public class ReportDocument : IDocument
    {
        private readonly IEnumerable<ReportRowDto> _rows;

        public ReportDocument(IEnumerable<ReportRowDto> rows)
        {
            _rows = rows;
        }

        public DocumentMetadata GetMetadata() => new DocumentMetadata();

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(20);

                page.Header().Element(Title);
                page.Content().Element(Content);

                page.Footer().AlignCenter().Text(text =>
                {
                    text.Span("OPI Reports · Página ");
                    text.CurrentPageNumber();
                    text.Span(" de ");
                    text.TotalPages();
                });
            });
        }

        void Title(IContainer c)
        {
            c.AlignCenter().Padding(6).Text(t =>
            {
                t.Span("OPI Reports").FontSize(18).Bold();
            });
        }

        void Content(IContainer c)
        {
            c.Column(col =>
            {
                col.Item().Element(HeaderRow);

                foreach (var r in _rows)
                    col.Item().Element(ctx => DataRow(ctx, r));
            });
        }

        void HeaderRow(IContainer c)
        {
            c.PaddingBottom(6).Row(row =>
            {
                row.ConstantItem(90).Padding(4).Background("#EFEFEF").Text(t => t.Span("Asignado a").Bold());
                row.ConstantItem(70).Padding(4).Background("#EFEFEF").Text(t => t.Span("Rol").Bold());
                row.ConstantItem(120).Padding(4).Background("#EFEFEF").Text(t => t.Span("Proyecto").Bold());
                row.ConstantItem(70).Padding(4).Background("#EFEFEF").Text(t => t.Span("Fecha").Bold());
                row.RelativeItem().Padding(4).Background("#EFEFEF").Text(t => t.Span("Descripción").Bold());
                row.ConstantItem(70).Padding(4).Background("#EFEFEF").Text(t => t.Span("Horas P").Bold());
                row.ConstantItem(70).Padding(4).Background("#EFEFEF").Text(t => t.Span("Horas R").Bold());
            });
        }

        void DataRow(IContainer c, ReportRowDto r)
        {
            c.Row(row =>
            {
                row.ConstantItem(90).Padding(4).Text(r.AsignadoA ?? "");
                row.ConstantItem(70).Padding(4).Text(r.Rol ?? "");
                row.ConstantItem(120).Padding(4).Text(r.Proyecto ?? "");
                row.ConstantItem(70).Padding(4).Text(r.FechaReporte.ToString("yyyy-MM-dd"));
                row.RelativeItem().Padding(4).Text(r.Descripcion ?? "");
                row.ConstantItem(70).Padding(4).AlignRight().Text(r.HorasPlaneadas.ToString());
                row.ConstantItem(70).Padding(4).AlignRight().Text(r.HorasReales.ToString());
            });
        }
    }
}

