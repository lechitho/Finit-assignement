using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Domain.Tasks.Requests
{
    public class TaskUpdateRequest
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
