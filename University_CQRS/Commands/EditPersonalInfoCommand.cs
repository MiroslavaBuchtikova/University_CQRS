using MediatR;


namespace University_CQRS.Commands
{
    public sealed class EditPersonalInfoCommand : IRequest<Unit>
    {
        public string SSN { get; }
        public string Name { get; }
        public string Email { get; }

        public EditPersonalInfoCommand(string ssn, string name, string email)
        {
            SSN = ssn;
            Name = name;
            Email = email;

        }
    }
}
