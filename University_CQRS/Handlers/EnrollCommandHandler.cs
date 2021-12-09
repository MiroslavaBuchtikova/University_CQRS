
using MediatR;
using University_CQRS.Commands;
using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class EnrollCommandHandler : IRequestHandler<EnrollCommand, Unit>
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;

        public EnrollCommandHandler(StudentRepository studentRepository,
            CourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(EnrollCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetById(request.StudentId);
            if (student == null)
                throw new Exception($"No student found with Id {request.StudentId}");

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

            return Unit.Value;
        }
    }
}