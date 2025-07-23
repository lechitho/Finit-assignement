using Finit.Application.ViewModels;

/*
 * Application service is that layer which initializes and oversees interaction 
 * between the domain objects and services. The flow is generally like this: 
 * get domain object (or objects) from repository, execute an action and put it 
 * (them) back there (or not). It can do more - for instance it can check whether 
 * a domain object exists or not and throw exceptions accordingly. So it lets the 
 * user interact with the application (and this is probably where its name originates 
 * from) - by manipulating domain objects and services. Application services should 
 * generally represent all possible use cases.
 */

namespace Finit.Application.Services.Interface
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetAll();
        Task<TaskViewModel> GetById(Guid id);
        Task<TaskViewModel> Create(TaskViewModel taskViewModel);
        Task<TaskViewModel> Update(TaskViewModel taskViewModel);
        Task Delete(Guid id);
    }
}
