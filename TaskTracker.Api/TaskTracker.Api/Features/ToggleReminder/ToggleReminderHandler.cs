using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Api.Data;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Features.ToggleReminder
{
    public class ToggleReminderHandler : IRequestHandler<ToggleReminderCommand, ToDo>
    {
        private TodoContext _context;

        public ToggleReminderHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<ToDo> Handle(ToggleReminderCommand request, CancellationToken cancellationToken)
        {
            var task = await _context
                .Todos
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            task.Reminder = request.Reminder;

            await _context.SaveChangesAsync(cancellationToken);

            return task;
        }
    }
}
