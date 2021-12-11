using MediatR;

namespace University_CQRS.Commands
{
    public sealed class UnregisterCommand : IRequest<ResultDto>
    {
        public string SSN { get; }

        public UnregisterCommand(string ssn)
        {
            SSN = ssn;
        }
    }
}