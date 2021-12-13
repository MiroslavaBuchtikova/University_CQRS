
using MediatR;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class UnregisterCommandHandler : IRequestHandler<UnregisterCommand, ResultDto>
    {
        private readonly StudentRepository _studentRepository;
        private readonly StudentReadRepository _studentReadRepository;

        public UnregisterCommandHandler(StudentRepository studentRepository, StudentReadRepository studentReadRepository)
        {
            _studentRepository = studentRepository;
            _studentReadRepository = studentReadRepository;
        }

        public async Task<ResultDto> Handle(UnregisterCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentReadRepository.GetBySSN(request.SSN);;
            if (student == null)
                throw new Exception($"No student found for SSN {request.SSN}");

            _studentRepository.Delete(student);

            return new ResultDto(true);
        }
    }
}