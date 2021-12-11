
using MediatR;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class UnregisterCommandHandler : IRequestHandler<UnregisterCommand, Unit>
    {
        private readonly StudentRepository _studentRepository;

        public UnregisterCommandHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(UnregisterCommand request, CancellationToken cancellationToken)
        {
            Student student = _studentRepository.GetById(request.StudentId);
            if (student == null)
                throw new Exception($"No student found for Id {request.StudentId}");

            _studentRepository.Delete(student);

            return Unit.Value;
        }
    }
}