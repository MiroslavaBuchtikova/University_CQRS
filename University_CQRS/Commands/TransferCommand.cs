using MediatR;


namespace University_CQRS.Commands
{
    public sealed class TransferCommand : IRequest<Unit>
    {
        public long StudentId { get; }
        public int EnrollmentIndex { get; }
        public string Course { get; }
        public string Grade { get; }

        public TransferCommand(long studentId, int enrollmentIndex, string course, string grade)
        {
            StudentId = studentId;
            EnrollmentIndex = enrollmentIndex;
            Course = course;
            Grade = grade;
        }
    }
}