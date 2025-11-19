using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opi.Reports.Domain.Enums
{
    public enum ReportStatus
    {
        Pending = 0,
        Generated = 1,
        Exported = 2,
        Error = 3
    }
}
