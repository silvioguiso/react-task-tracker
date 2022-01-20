using MediatR;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Features.ToggleReminder
{
    public class ToggleReminderCommand : IRequest<ToDo>
    {
        public int Id { get; set; }
        public bool Reminder { get; set; }
        public string Day { get; set; }
        public string Text { get; set; }
    }
}
