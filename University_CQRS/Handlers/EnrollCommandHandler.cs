
using MediatR;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class EnrollCommandHandler : IRequestHandler<EnrollCommand, ResultDto>
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly StudentReadRepository _studentReadRepository;

        public EnrollCommandHandler(StudentRepository studentRepository,
            CourseRepository courseRepository, StudentReadRepository studentReadRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _studentReadRepository = studentReadRepository;
        }

        public async Task<ResultDto> Handle(EnrollCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentReadRepository.GetBySSN(request.SSN);;
            if (student == null)
                throw new Exception($"No student found with SSN {request.SSN}");

            Course course = _courseRepository.GetByName(request.Course);
            if (course == null)
                throw new Exception($"Course is incorrect: '{request.Course}'");

            bool success = Enum.TryParse(request.Grade, out Grade grade);
            if (!success)
                throw new Exception($"Grade is incorrect: '{request.Grade}'");

            if (student.Enrollments?.Count >= 2)
                throw new Exception("Cannot have more than 2 enrollments");

            var enrollment = new Enrollment
            {
                Course = course,
                Grade = grade
            };

            if (student.Enrollments == null)
            {
                student.Enrollments = new List<Enrollment>();
            }

            student.Enrollments.Add(enrollment);
             _studentRepository.Save(student);

            return new ResultDto(true);
        }
    }
}