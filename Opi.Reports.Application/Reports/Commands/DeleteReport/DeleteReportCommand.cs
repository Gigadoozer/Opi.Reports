using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Opi.Reports.Application.Reports.Commands.DeleteReport
{
    public class DeleteReportCommand : IRequest<bool>
    {
        public DeleteReportCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
