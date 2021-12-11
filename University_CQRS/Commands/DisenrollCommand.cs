using MediatR;

namespace University_CQRS.Commands
{
    public class DisenrollCommand : IRequest<Unit>
    {
        public string SSN { get; }
        public int EnrollmentIndex { get; }
        public string Comment { get; }

        public DisenrollCommand(string ssn, int enrollmentIndex, string comment)
        {
            SSN = ssn;
            EnrollmentIndex = enrollmentIndex;
            Comment = comment;
        }
    }
}