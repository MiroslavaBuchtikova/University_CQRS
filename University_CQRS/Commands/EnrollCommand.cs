using MediatR;
using University_CQRS.Dtos;

namespace University_CQRS.Commands
{
    public sealed class EnrollCommand : IRequest<ResultDto>
    {
        public long Id { get; }
        public string Course { get; }
        public string Grade { get; }

        public EnrollCommand(long id, string course, string grade)
        {
            Id = id;
            Course = course;
            Grade = grade;
        }
    }
}