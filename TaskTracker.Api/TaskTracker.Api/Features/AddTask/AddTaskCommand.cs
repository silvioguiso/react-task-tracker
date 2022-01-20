using MediatR;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Features.AddTask
{
    public class AddTaskCommand : IRequest<ToDo>
    {
        public string Text { get; set; }
        public string Day { get; set; }
        public bool Reminder { get; set; }
    }
}
