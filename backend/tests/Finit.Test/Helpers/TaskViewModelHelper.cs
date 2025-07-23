using Finit.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Test.Helpers
{
    public static class TaskViewModelHelper
    {
        public static TaskViewModel GetTaskViewModel()
        {
            return new TaskViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Title",
                Description = "Description"
            };
        }
    }
}
