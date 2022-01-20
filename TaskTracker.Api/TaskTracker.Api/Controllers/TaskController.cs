using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Api.Features.AddTask;
using TaskTracker.Api.Features.DeleteTasks;
using TaskTracker.Api.Features.GetTasks;
using TaskTracker.Api.Features.ToggleReminder;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ToDo>> GetTasks()
            => await _mediator.Send(new GetTasksCommand());

        [HttpGet]
        [Route("{id}")]
        public async Task<ToDo> GetTask(int id)
        {
            var taskList = await _mediator.Send(new GetTasksCommand(id));
            return taskList.FirstOrDefault();
        }

        [HttpPost]
        [Route("add")]
        public async Task<ToDo> AddTask([FromBody] AddTaskCommand command)
            => await _mediator.Send(command);

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task DeleteTask(int id)
            => await _mediator.Send(new DeleteTaskCommand(id));

        [HttpPut]
        [Route("toggle")]
        public async Task<ToDo> ToggleReminder([FromBody] ToggleReminderCommand command)
            => await _mediator.Send(command);
    }
}
