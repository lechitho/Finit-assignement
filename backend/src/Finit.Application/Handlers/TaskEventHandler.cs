using Finit.Domain.Tasks.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Application.Handlers
{
    public class TaskEventHandler
    {
        public async Task HandleTaskCreatedEvent(TaskCreatedEvent taskCreatedEvent)
        {
            // Here to do whatever need with this event, we can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, we are building a event driven architecture with microservices and DDD
        }
        public async Task HandleTaskUpdatedEvent(TaskUpdatedEvent taskUpdatedEvent)
        {
            // Here to do whatever need with this event, we can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, we are building a event driven architecture with microservices and DDD
        }
        public async Task HandleTaskDeletedEvent(TaskDeletedEvent taskDeletedEvent)
        {
            // Here to do whatever need with this event, we can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, we are building a event driven architecture with microservices and DDD
        }

    }
}
