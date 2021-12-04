
using MediatR;
using University_CQRS.Commands;
using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class EnrollCommandHandler : IRequestHandler<EnrollCommand, ResultDto>
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;

        public EnrollCommandHandler(StudentRepository studentRepository,
            CourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<ResultDto> Handle(EnrollCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetById(request.Id);
            if (student == null)
                throw new Exception($"No student found with Id {request.Id}");

            Course course = _courseRepository.GetByName(request.Course);
            if (course == null)
                throw new Exception($"Course is incorrect: '{request.Course}'");

            bool success = Enum.TryParse(request.Grade, out Grade grade);
            if (!success)
                throw new Exception($"Grade is incorrect: '{request.Grade}'");

            student.Enroll(course, grade);
            await _studentRepository.SaveAsync(student);

            return new ResultDto(student.Id, true);
        }
    }
}