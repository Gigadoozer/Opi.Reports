using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opi.Reports.Domain.Entities
{
    public class FilaReporte
    {
        public string AsignadoA { get; set; }
        public string Rol { get; set; }
        public string Proyecto { get; set; }
        public DateTime FechaReporte { get; set; }
        public string Descripcion { get; set; }
        public decimal HorasPlaneadas { get; set; }
        public decimal HorasReales { get; set; }
    }
}
