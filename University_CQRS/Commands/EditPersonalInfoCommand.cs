using MediatR;


namespace University_CQRS.Commands
{
    public sealed class EditPersonalInfoCommand : IRequest<Unit>
    {
        public long Id { get; }
        public string Name { get; }
        public string Email { get; }

        public EditPersonalInfoCommand(long id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;

        }
    }
}
