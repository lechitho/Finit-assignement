using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Domain.Tasks.Events
{
    public class TaskDeletedEvent : TaskEvent
    {
        public TaskDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
