using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opi.Reports.Domain.Entities
{
    public class ReporteGeneral
    {
        public string Titulo { get; set; } = "OPI Reports";
        public string Periodo { get; set; }
        public List<FilaReporte> Filas { get; set; } = new();
    }
}
