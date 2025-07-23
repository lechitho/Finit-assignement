using Microsoft.AspNetCore.Http;
using Finit.Application.ViewModels;
using Finit.Domain.Tasks;
using Finit.Domain.Tasks.Commands;

/*
 * A view model represents the data that you want to display on 
 * your view/page, whether it be used for static text or for input
 * values (like textboxes and dropdown lists). It is something 
 * different than your domain model. So we need to convert the 
 * domain model to a view model to send it to the client (API response)
 
 */

namespace Finit.Application.Mappers
{
    public class TaskViewModelMapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskViewModelMapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<TaskViewModel> ConstructFromListOfEntities(IEnumerable<TaskInfo> tasks)
        {
            var tasksViewModel = tasks.Select(p => new TaskViewModel
            {
                Id = p.TaskId.ToGuid().ToString(),
                Title = p.Title,
                Description = p.Description,
            });

            return tasksViewModel;
        }

        public TaskViewModel ConstructFromEntity(TaskInfo task)
        {
            return new TaskViewModel
            {
                Id = task.TaskId.ToGuid().ToString(),
                Title = task.Title,
                Description = task.Description,
                
            };
        }

        public CreateNewTaskCommand ConvertToNewTaskCommand(TaskViewModel taskViewModel)
        {
            return new CreateNewTaskCommand(taskViewModel.Title, taskViewModel.Description);
        }
        public UpdateTaskCommand ConvertToUpdateTaskCommand(TaskViewModel taskViewModel)
        {
            return new UpdateTaskCommand(new Guid(taskViewModel.Id), taskViewModel.Title, taskViewModel.Description);
        }

        public DeleteTaskCommand ConvertToDeleteTaskCommand(Guid id)
        {
            return new DeleteTaskCommand(id);
        }
    }
}
