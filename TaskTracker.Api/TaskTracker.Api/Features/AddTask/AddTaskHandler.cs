using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Api.Data;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Features.AddTask
{
    public class AddTaskHandler : IRequestHandler<AddTaskCommand, ToDo>
    {
        private readonly TodoContext _context;
        public AddTaskHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<ToDo> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        {
            var newTask = 
                new ToDo(request.Text, request.Day, request.Reminder);
            
            await _context
                .Todos
                .AddAsync(newTask, cancellationToken);
            
            await _context
                .SaveChangesAsync(cancellationToken);
            
            return newTask;
        }
    }
}
