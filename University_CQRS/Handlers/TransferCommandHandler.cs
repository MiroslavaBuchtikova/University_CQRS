
using MediatR;
using University_CQRS.Commands;
using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class TransferCommandHandler : IRequestHandler<TransferCommand, Unit>
    {
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        public TransferCommandHandler(StudentRepository studentRepository, CourseRepository courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<Unit> Handle(TransferCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetById(request.Id);
            if (student == null)
                throw new Exception($"No student found with Id '{request.Id}'");

            Course course = _courseRepository.GetByName(request.Course);
            if (course == null)
                throw new Exception($"Course is incorrect: '{request.Course}'");

            bool success = Enum.TryParse(request.Grade, out Grade grade);
            if (!success)
                throw new Exception($"Grade is incorrect: '{request.Grade}'");

            Enrollment enrollment = student.Enrollments.Count > request.EnrollmentIndex ? student.Enrollments[request.EnrollmentIndex] : null;
            if (enrollment == null)
                throw new Exception($"No enrollment found with number '{request.EnrollmentIndex}'");

            enrollment.Course = course;
            enrollment.Grade = grade; 

             _studentRepository.Save(student);

            return Unit.Value;
        }
    }
}