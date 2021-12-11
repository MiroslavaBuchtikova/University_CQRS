
using MediatR;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class UnregisterCommandHandler : IRequestHandler<UnregisterCommand, ResultDto>
    {
        private readonly StudentRepository _studentRepository;

        public UnregisterCommandHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ResultDto> Handle(UnregisterCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetBySSN(request.SSN);;
            if (student == null)
                throw new Exception($"No student found for SSN {request.SSN}");

            _studentRepository.Delete(student);

            return new ResultDto(true);
        }
    }
}