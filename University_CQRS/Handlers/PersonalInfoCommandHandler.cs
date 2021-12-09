
using MediatR;
using University_CQRS.Commands;
using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class PersonalInfoCommandHandler : IRequestHandler<EditPersonalInfoCommand, Unit>
    {
        private readonly StudentRepository _studentRepository;

        public PersonalInfoCommandHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(EditPersonalInfoCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetById(request.Id);

            if (student == null)
                throw new Exception($"No student found for Id {request.Id}");

            student.Name = request.Name;
            student.Email = request.Email;

             _studentRepository.Save(student);
            return Unit.Value;
        }
    }
}