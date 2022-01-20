using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Api.Data;

namespace TaskTracker.Api.Features.AddTask
{

    public class AddTaskValidator : AbstractValidator<AddTaskCommand>
    {
        private readonly TodoContext _context;

        public AddTaskValidator(TodoContext context)
        {
            _context = context;

            RuleFor(x => x.Text)
                .NotEmpty();

            RuleFor(x => x.Day)
                .NotEmpty();

            RuleFor(x => x)
                .MustAsync(BeUnique)
                .WithMessage(x => $"You already have a Task created for '{x.Text}' on '{x.Day}'");
        }

        private async Task<bool> BeUnique(AddTaskCommand todo, CancellationToken token)
        {
            var itemExists = await _context
                .Todos
                .AnyAsync(x => x.Text == todo.Text && x.Day == todo.Day, token);

            return !itemExists;
        }
    }
}
