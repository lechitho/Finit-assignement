using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finit.Application.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {

        }
        public TaskViewModel(Guid? taskId, string title, string description)
        {
            Id = taskId?.ToString();
            Title = title;
            Description = description;
        }

        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(1500)]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; } = "";
    }
}
