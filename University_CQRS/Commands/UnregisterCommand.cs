using MediatR;

namespace University_CQRS.Commands
{
    public sealed class UnregisterCommand : IRequest<Unit>
    {
        public long StudentId { get; }

        public UnregisterCommand(long id)
        {
            StudentId = id;
        }
    }
}