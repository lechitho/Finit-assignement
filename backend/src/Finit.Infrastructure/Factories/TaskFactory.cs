using Finit.Domain.Tasks;
using Finit.Domain.Tasks.Requests;
using Finit.Domain.Tasks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Infrastructure.Factories
{
    public class TaskFactory : TaskInfo
    {
        public TaskFactory()
        {

        }

        public TaskFactory(TaskCreateRequest taskCreateRequest)
        {
            TaskId = new TaskId(Guid.NewGuid());
            Title = taskCreateRequest.Title;
            Description = taskCreateRequest.Description;
        }
        public TaskFactory(TaskUpdateRequest taskUpdateRequest)
        {
            TaskId = new TaskId(taskUpdateRequest.Id);
            Title = taskUpdateRequest.Title;
            Description = taskUpdateRequest.Description;
        }
    }
}
