using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Domain.Tasks.Commands
{
    public class DeleteTaskCommand : TaskCommand
    {
        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
