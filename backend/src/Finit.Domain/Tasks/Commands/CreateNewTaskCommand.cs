using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Domain.Tasks.Commands
{
    public class CreateNewTaskCommand : TaskCommand
    {
        public CreateNewTaskCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
