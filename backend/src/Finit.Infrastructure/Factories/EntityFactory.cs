using Finit.Domain.Tasks;
using Finit.Domain.Tasks.Interface;
using Finit.Domain.Tasks.Requests;

namespace Finit.Infrastructure.Factories
{
    public class EntityFactory : ITaskFactory
    {
        public TaskInfo CreateTaskInstance(TaskCreateRequest taskCreateRequest)
        {
            return new TaskFactory(taskCreateRequest);
        }

        public TaskInfo UpdateTaskInstance(TaskUpdateRequest taskUpdateRequest)
        {
            return new TaskFactory(taskUpdateRequest);
        }
    }
}
