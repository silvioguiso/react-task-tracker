using MediatR;

namespace TaskTracker.Api.Features.DeleteTasks
{
    public class DeleteTaskCommand : IRequest
    {
        public DeleteTaskCommand()
        {

        }

        public DeleteTaskCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
