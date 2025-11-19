using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opi.Reports.Application.DTOs
{
    public class ReportRowDto
    {
        public string AsignadoA { get; set; } = "";
        public string Rol { get; set; } = "";
        public string Proyecto { get; set; } = "";

        public DateTime FechaReporte { get; set; }

        public string Descripcion { get; set; } = "";

        public int HorasPlaneadas { get; set; }
        public int HorasReales { get; set; }
    }
}
