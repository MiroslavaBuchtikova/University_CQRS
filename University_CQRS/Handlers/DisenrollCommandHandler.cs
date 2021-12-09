
using MediatR;
using University_CQRS.Commands;
using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class DisenrollCommandHandler : IRequestHandler<DisenrollCommand, ResultDto>
    {
        private readonly StudentRepository _studentRepository;

        public DisenrollCommandHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ResultDto> Handle(DisenrollCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetById(request.Id);
            if (student == null)
                throw new Exception($"No student found for Id {request.Id}");

            if (string.IsNullOrWhiteSpace(request.Comment))
                throw new Exception("Disenrollment comment is required");

            Enrollment enrollment = student.Enrollments.SingleOrDefault(w => w.Id == request.EnrollmentNumber);
            if (enrollment == null)
                throw new Exception($"No enrollment found with number '{request.EnrollmentNumber}'");

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

            return new ResultDto(student.Id, true);
        }
    }
}