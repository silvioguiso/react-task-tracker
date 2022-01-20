using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Api.Data;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Features.GetTasks
{
    public class GetTasksHandler : IRequestHandler<GetTasksCommand, IEnumerable<ToDo>>
    {
        private readonly TodoContext _context;
        public GetTasksHandler(TodoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDo>> Handle(GetTasksCommand request, CancellationToken cancellationToken)
        {
            return await 
                BuildQuery(request)
                .ToListAsync(cancellationToken);
        }

        private IQueryable<ToDo> BuildQuery(GetTasksCommand request)
        {
            var query = _context
                .Todos
                .AsQueryable();

            if (request.Id > 0)
            {
                query = query
                    .Where(x => x.Id == request.Id);
            }

            return query
                .AsNoTracking();
        }
    }
}
