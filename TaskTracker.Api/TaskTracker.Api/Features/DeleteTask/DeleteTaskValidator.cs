using FluentValidation;
using TaskTracker.Api.Data;
using TaskTracker.Api.Features.DeleteTasks;

namespace TaskTracker.Api.Features.DeleteTask
{
    public class DeleteTaskValidator : AbstractValidator<DeleteTaskCommand>
    {
        private readonly TodoContext _context;

        public DeleteTaskValidator(TodoContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("You must provide an Id value to delete a task.");
        }
    }
}
