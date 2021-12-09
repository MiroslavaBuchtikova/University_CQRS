using MediatR;


namespace University_CQRS.Commands
{
    public sealed class EnrollCommand : IRequest<Unit>
    {
        public long StudentId { get; }
        public string Course { get; }
        public string Grade { get; }

        public EnrollCommand(long id, string course, string grade)
        {
            StudentId = id;
            Course = course;
            Grade = grade;
        }
    }
}