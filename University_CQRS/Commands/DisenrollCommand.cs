using MediatR;

namespace University_CQRS.Commands
{
    public class DisenrollCommand : IRequest<ResultDto>
    {
        public long Id { get; }
        public int EnrollmentIndex { get; }
        public string Comment { get; }

        public DisenrollCommand(long id, int enrollmentIndex, string comment)
        {
            Id = id;
            EnrollmentIndex = enrollmentIndex;
            Comment = comment;
        }
    }
}