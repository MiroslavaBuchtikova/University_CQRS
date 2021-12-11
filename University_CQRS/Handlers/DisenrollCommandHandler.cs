
using MediatR;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class DisenrollCommandHandler : IRequestHandler<DisenrollCommand, Unit>
    {
        private readonly StudentRepository _studentRepository;

        public DisenrollCommandHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DisenrollCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetById(request.StudentId);
            if (student == null)
                throw new Exception($"No student found for Id {request.StudentId}");

            if (string.IsNullOrWhiteSpace(request.Comment))
                throw new Exception("Disenrollment comment is required");

            Enrollment enrollment = student.Enrollments.Count > request.EnrollmentIndex ? student.Enrollments[request.EnrollmentIndex] : null;
            if (enrollment == null)
                throw new Exception($"No enrollment found with number '{request.EnrollmentIndex}'");

            student.Enrollments.Remove(enrollment);

            var disenrollment = new Disenrollment
            {
                Student = student,
                Course = enrollment.Course,
                Comment = request.Comment,
                DateTime = DateTime.Now
            };
            if (student.Disenrollments == null)
            {
                student.Disenrollments = new List<Disenrollment>();
            }
            student.Disenrollments.Add(disenrollment);

            _studentRepository.Save(student);

            return Unit.Value;
        }
    }
}