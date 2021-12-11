

namespace University_CQRS.Mapping
{
    public static class StudentMapper
    {
        public static StudentDto Map(this ReadStudent readStudentModel)
        {

            var studentDto = new StudentDto
            {
                SSN = readStudentModel.SSN,
                Name = readStudentModel.Name,
                Email = readStudentModel.Email,

                Course1 = readStudentModel.Course1,
                Course1Grade = readStudentModel.Course1Grade,
                Course1Credits = readStudentModel.Course1Credits,
                Course1DisenrollmentComment = readStudentModel.Course1DisenrollmentComment,

                Course2 = readStudentModel.Course2,
                Course2Grade = readStudentModel.Course2Grade,
                Course2Credits = readStudentModel.Course2Credits,
                Course2DisenrollmentComment = readStudentModel.Course2DisenrollmentComment
            };
            return studentDto;
        }

        public static List<StudentDto> Map(this IReadOnlyList<ReadStudent> readStudentModels)
        {
            return readStudentModels.Select(a => a.Map()).ToList();
        }
    }
}

