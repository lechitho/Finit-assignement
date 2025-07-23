using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Domain.Tasks.Events
{
    public class TaskEvent
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

    }
}
