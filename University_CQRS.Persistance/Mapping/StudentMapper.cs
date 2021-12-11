namespace University_CQRS.Persistance.Mapping
{
    public static class StudentMapper
    {
        public static StudentAggregate Map(this Student student)
        {

            var studentAggregate = new StudentAggregate
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                NumberOfEnrollments = student.Enrollments.Count
            };

            if (student.Enrollments?.Count > 0)
            {
                studentAggregate.FirstCourseName = student.Enrollments?[0]?.Course?.Name;
                studentAggregate.FirstCourseGrade = student.Enrollments?[0]?.Grade.ToString();
                studentAggregate.FirstCourseCredits = student.Enrollments?[0]?.Course?.Credits;
            }
            if (student.Enrollments?.Count > 1)
            {

                studentAggregate.SecondCourseName = student.Enrollments?[1]?.Course?.Name;
                studentAggregate.SecondCourseGrade = student.Enrollments?[1]?.Grade.ToString();
                studentAggregate.SecondCourseCredits = student.Enrollments?[1]?.Course?.Credits;
            }

            return studentAggregate;
        }

        //public static List<StudentAggreagate> Map(this IEnumerable<Student> students)
        //{
        //    return students.Select(a => a.Map()).ToList();
        //}
    }
}

