using MediatR;


namespace University_CQRS.Commands
{
    public sealed class TransferCommand : IRequest<ResultDto>
    {
        public long Id { get; }
        public int EnrollmentIndex { get; }
        public string Course { get; }
        public string Grade { get; }

        public TransferCommand(long id, int enrollmentIndex, string course, string grade)
        {
            Id = id;
            EnrollmentIndex = enrollmentIndex;
            Course = course;
            Grade = grade;
        }
    }
}