using MediatR;


namespace University_CQRS.Commands
{
    public sealed class EditPersonalInfoCommand : IRequest<Unit>
    {
        public long StudentId { get; }
        public string Name { get; }
        public string Email { get; }

        public EditPersonalInfoCommand(long studentId, string name, string email)
        {
            StudentId = studentId;
            Name = name;
            Email = email;

        }
    }
}
