using Finit.Domain.Tasks;
using Finit.Domain.Tasks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Test.Helpers
{
    public class TaskInfoHelper
    {
        public static TaskInfo GetTask()
        {
            return new TaskInfo()
            {
                TaskId = new TaskId(Guid.NewGuid()),
                Title = "Title",
                Description = "Description"
            };
        }

        public static IEnumerable<TaskInfo> GetTasks()
        {
            return new List<TaskInfo>()
            {
                GetTask()
            };
        }
    }
}
