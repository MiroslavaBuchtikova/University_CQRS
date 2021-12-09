using MediatR;

namespace University_CQRS.Commands
{
    public sealed class UnregisterCommand : IRequest<Unit>
    {
        public long Id { get; }

        public UnregisterCommand(long id)
        {
            Id = id;
        }
    }
}