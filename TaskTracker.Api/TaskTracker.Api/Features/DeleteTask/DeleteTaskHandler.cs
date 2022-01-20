using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Api.Data;
using TaskTracker.Api.Features.DeleteTasks;

namespace TaskTracker.Api.Features.DeleteTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand>
    {
        private TodoContext _context;
        public DeleteTaskHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _context
                .Todos
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            
            if(task != null)
            {
                _context
                    .Todos
                    .Remove(task);
                
                await _context
                    .SaveChangesAsync(cancellationToken);
            }

            return await Task.FromResult(Unit.Value);
        }
    }
}
