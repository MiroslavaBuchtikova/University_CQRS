
using MediatR;
using University_CQRS.Commands;

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
            if (request.SSN == null)
            {
                throw new Exception($"SSN cant't be null");
            }
            var studentExists = _studentRepository.GetBySSN(request.SSN);
            if(studentExists !=null)
            {
                throw new Exception("Student with this SSN already exists");
            }
            var student = new Student
            {
                SSN = request.SSN,
                Name = request.Name,
                Email = request.Email
            };

            AddEnrollment(request.Course1, request.Course1Grade, student);
            AddEnrollment(request.Course2, request.Course2Grade, student);

            _studentRepository.Save(student);

            return new ResultDto(true);
        }

        public void AddEnrollment(string courseName, string grade, Student student)
        {
            Course course = _courseRepository.GetByName(courseName);
            if (student.Enrollments?.Count >= 2)
                throw new Exception("Cannot have more than 2 enrollments");

            var enrollment = new Enrollment
            {
                Course = course,
                Grade = Enum.Parse<Grade>(grade)
            };

            if (student.Enrollments == null)
            {
                student.Enrollments = new List<Enrollment>();
            }

            student.Enrollments.Add(enrollment);
        }
    }
}