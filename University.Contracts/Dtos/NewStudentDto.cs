public class NewStudentDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<StudentEnrollmentDto> Enrollments { get; set; }
}