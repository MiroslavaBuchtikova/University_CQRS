
using MediatR;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class PersonalInfoCommandHandler : IRequestHandler<EditPersonalInfoCommand, ResultDto>
    {
        private readonly StudentRepository _studentRepository;

        public PersonalInfoCommandHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ResultDto> Handle(EditPersonalInfoCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetBySSN(request.SSN);

            if (student == null)
                throw new Exception($"No student found for SSN {request.SSN}");

            student.Name = request.Name;
            student.Email = request.Email;

             _studentRepository.Save(student);
            return new ResultDto(true);
        }
    }
}