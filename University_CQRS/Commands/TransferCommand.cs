using MediatR;


namespace University_CQRS.Commands
{
    public sealed class TransferCommand : IRequest<Unit>
    {
        public string SSN { get; }
        public int EnrollmentIndex { get; }
        public string Course { get; }
        public string Grade { get; }

        public TransferCommand(string ssn, int enrollmentIndex, string course, string grade)
        {
            SSN = ssn;
            EnrollmentIndex = enrollmentIndex;
            Course = course;
            Grade = grade;
        }
    }
}