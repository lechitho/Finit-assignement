using Finit.Application.Services.Interface;
using Finit.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Finit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;


        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Get Tasks
        /// </summary>
        /// <returns>Returns a list of All Tasks</returns>
        [HttpGet]
        [ProducesResponseType(typeof(TaskViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _taskService.GetAll());
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        /// <summary>
        /// Get Task by ID
        /// </summary>
        /// <param name="id">Task's ID</param>
        /// <returns>Returns a Task by its ID</returns>
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(TaskViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _taskService.GetById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        /// <summary>
        /// Create a new Task
        /// </summary>
        /// <param name="taskViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(TaskViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] TaskViewModel taskViewModel)
        {
            try
            {
                return Ok(await _taskService.Create(taskViewModel));
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        /// <summary>
        /// Update existed Task
        /// </summary>
        /// <param name="taskViewModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaskViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromBody] TaskViewModel taskViewModel)
        {
            try
            {
                return Ok(await _taskService.Update(taskViewModel));
            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a Task
        /// </summary>
        /// <param name="id">Task's ID</param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "Delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _taskService.Delete(id);
                return StatusCode(StatusCodes.Status204NoContent);

            }
            catch (Exception ex)
            {
                Log.Error($"Error: message: {ex.Message} ");

                return StatusCode(StatusCodes.Status500InternalServerError, new { exception_message = ex.Message });
            }
        }
    }
}
