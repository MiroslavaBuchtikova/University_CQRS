using MediatR;


namespace University_CQRS.Commands
{
    public sealed class EnrollCommand : IRequest<ResultDto>
    {
        public string SSN { get; }
        public string Course { get; }
        public string Grade { get; }

        public EnrollCommand(string ssn, string course, string grade)
        {
            SSN = ssn;
            Course = course;
            Grade = grade;
        }
    }
}