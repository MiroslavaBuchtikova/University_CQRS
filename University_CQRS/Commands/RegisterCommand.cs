using MediatR;


namespace University_CQRS.Commands
{
    public sealed class RegisterCommand : IRequest<ResultDto>
    {
        public string Name { get; }
        public string Email { get; }
        public List<RegisteredEnrollment> Enrollments { get; set; }

        public RegisterCommand(string name, string email, List<RegisteredEnrollment> enrollments)
        {
            Name = name;
            Email = email;
            Enrollments = enrollments;
        }
    }
    public class RegisteredEnrollment {
        public string Course { get; set; }
        public string Grade { get; set; }
    }
}