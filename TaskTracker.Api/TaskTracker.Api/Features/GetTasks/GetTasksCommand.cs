using MediatR;
using System.Collections.Generic;
using TaskTracker.Api.Models;

namespace TaskTracker.Api.Features.GetTasks
{
    public class GetTasksCommand : IRequest<IEnumerable<ToDo>>
    {
        public GetTasksCommand()
        {

        }

        public GetTasksCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
