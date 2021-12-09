using University_CQRS.Contracts.Dtos;
using University_CQRS.Contracts.Entities.Students;

namespace University_CQRS.Mapping
{
    public static class StudentMapper
    {
        public static StudentDto Map(this Student student)
        {

            var studentDto = new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Enrollments = student.Enrollments.Map()
            };

            return studentDto;
        }
        public static List<EnrollmentDto> Map(this IList<Enrollment> enrollments)
        {
            var mappedEnrolments = enrollments.Select(x => new EnrollmentDto
            {
                Id = x.Id,
                CourseCredit = x.Course.Credits,
                CourseGrade = x.Grade.ToString(),
                CourseName = x.Course.Name
            }).ToList();

            return mappedEnrolments;
        }

        public static List<StudentDto> Map(this IReadOnlyList<Student> students)
        {
            return students.Select(a => a.Map()).ToList();
        }
    }
}

