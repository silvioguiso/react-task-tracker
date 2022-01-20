using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Api.Data;

namespace TaskTracker.Api.Features.ToggleReminder
{
    public class ToggleReminderValidator : AbstractValidator<ToggleReminderCommand>
    {
        private readonly TodoContext _context;

        public ToggleReminderValidator(TodoContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .MustAsync(Exist)
                .WithMessage(x => $"Task with Id '{x.Id}' does not exist");
        }

        private async Task<bool> Exist(int id, CancellationToken token)
        {
            return await _context
                .Todos
                .AnyAsync(x => x.Id == id, token);
        }
    }
}
