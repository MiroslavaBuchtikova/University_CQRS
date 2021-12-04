
using MediatR;
using University_CQRS.Commands;
using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResultDto>
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;

        public RegisterCommandHandler(StudentRepository studentRepository,
            CourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<ResultDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var student = new Student(request.Name, request.Email);

            if (request.Course1 != null && request.Course1Grade != null)
            {
                Course course = _courseRepository.GetByName(request.Course1);
                student.Enroll(course, Enum.Parse<Grade>(request.Course1Grade));
            }

            if (request.Course2 != null && request.Course2Grade != null)
            {
                Course course = _courseRepository.GetByName(request.Course2);
                student.Enroll(course, Enum.Parse<Grade>(request.Course2Grade));
            }

            _studentRepository.Save(student);

            return new ResultDto(student.Id, true);
        }
    }
}