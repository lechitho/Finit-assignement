using Finit.Domain.Tasks.Requests;

/*
 * Factories are concerned with creating new entities and value objects. 
 * They also validate the invariants for the newly created objects.
 * 
 * This is the interface definition to create Tasks (to be implemented in
 * Infrastructure layer)
 */

namespace Finit.Domain.Tasks.Interface
{
    public interface ITaskFactory
    {
        TaskInfo CreateTaskInstance(TaskCreateRequest taskCreateRequest);
        TaskInfo UpdateTaskInstance(TaskUpdateRequest taskUpdateRequest);
    }
}
