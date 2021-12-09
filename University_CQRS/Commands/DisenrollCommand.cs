using MediatR;

namespace University_CQRS.Commands
{
    public class DisenrollCommand : IRequest<Unit>
    {
        public long StudentId { get; }
        public int EnrollmentIndex { get; }
        public string Comment { get; }

        public DisenrollCommand(long id, int enrollmentIndex, string comment)
        {
            StudentId = id;
            EnrollmentIndex = enrollmentIndex;
            Comment = comment;
        }
    }
}