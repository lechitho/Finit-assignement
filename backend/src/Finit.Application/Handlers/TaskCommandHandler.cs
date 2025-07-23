using FluentMediator;
using Finit.Domain.Tasks.Commands;
using Finit.Domain.Tasks.Events;
using Finit.Domain.Tasks.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finit.Domain.Tasks.Requests;

namespace Finit.Application.Handlers
{
    public class TaskCommandHandler
    {
        private readonly ITaskFactory _taskFactory;
        private readonly ITaskRepository _taskRepository;
        private readonly IMediator _mediator;

        public TaskCommandHandler(ITaskRepository taskRepository, ITaskFactory taskFactory, IMediator mediator)
        {
            _taskRepository = taskRepository;
            _taskFactory = taskFactory;
            _mediator = mediator;
        }

        public async Task<Domain.Tasks.TaskInfo> HandleNewTask(CreateNewTaskCommand createNewTaskCommand)
        {
            var task = _taskFactory.CreateTaskInstance(new TaskCreateRequest
                    { 
                        Title = createNewTaskCommand.Title, 
                        Description = createNewTaskCommand.Description 
                    });

            var taskCreated = await _taskRepository.Add(task);

            // raise an event in case need to propagate this change to other microservices
            await _mediator.PublishAsync(new TaskCreatedEvent(taskCreated.TaskId.ToGuid(),
                taskCreated.Title, taskCreated.Description));

            return taskCreated;
        }

        public async Task<Domain.Tasks.TaskInfo> HandleUpdateTask(UpdateTaskCommand updateNewTaskCommand)
        {
            var task = _taskFactory.UpdateTaskInstance(new TaskUpdateRequest
            {
                Id = updateNewTaskCommand.Id,
                Title = updateNewTaskCommand.Title,
                Description = updateNewTaskCommand.Description
            });

            var taskCreated = await _taskRepository.Update(task);

            // raise an event in case need to propagate this change to other microservices
            await _mediator.PublishAsync(new TaskUpdatedEvent(taskCreated.TaskId.ToGuid(),
                taskCreated.Title, taskCreated.Description));

            return taskCreated;
        }

        public async System.Threading.Tasks.Task HandleDeleteTask(DeleteTaskCommand deleteTaskCommand)
        {
            await _taskRepository.Remove(deleteTaskCommand.Id);

            // raise an event in case need to propagate this change to other microservices
            await _mediator.PublishAsync(new TaskDeletedEvent(deleteTaskCommand.Id));
        }
    }
}
