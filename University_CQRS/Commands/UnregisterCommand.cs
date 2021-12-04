using MediatR;

namespace University_CQRS.Commands
{
    public sealed class UnregisterCommand : IRequest<ResultDto>
    {
        public long Id { get; }

        public UnregisterCommand(long id)
        {
            Id = id;
        }
    }
}