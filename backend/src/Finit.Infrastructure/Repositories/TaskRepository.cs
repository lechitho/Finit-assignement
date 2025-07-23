using Finit.Domain.Tasks;
using Finit.Domain.Tasks.Interface;
using Finit.Domain.Tasks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ITaskFactory _taskFactory;
        private readonly List<TaskInfo> _tasks = new();

        public TaskRepository(ITaskFactory taskFactory)
        {
            _taskFactory = taskFactory;
        }

        public Task<TaskInfo> Add(TaskInfo taskEntity)
        {
            TaskInfo task = new()
            {
                TaskId = new TaskId(Guid.NewGuid()),
                Title = taskEntity.Title,
                Description = taskEntity.Description,
            };
            _tasks.Add(task);
            return Task.FromResult(task);
        }
        public Task<TaskInfo> Update(TaskInfo entity)
        {
            var task = FindById(entity.TaskId.ToGuid());
            if (task == null) return Task.FromResult(new TaskInfo());

            task.Result.Title = entity.Title;
            task.Result.Description = entity.Description;

            return Task.FromResult(entity);
        }

        public Task<List<TaskInfo>> FindAll() => Task.FromResult(_tasks);

        public Task<TaskInfo> FindById(Guid id)
        {
            return Task.FromResult(_tasks.FirstOrDefault(p => p.TaskId.ToGuid() == id));
        }

        public Task Remove(Guid id)
        {
            var task = _tasks.FirstOrDefault(p => p.TaskId.ToGuid() == id);
            if (task != null) _tasks.Remove(task);

            return Task.CompletedTask;
        }

        
    }
}
