
using MediatR;
using MediatR.Pipeline;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class UnregisterCommandHandlerPostProcessor : IRequestPostProcessor<UnregisterCommand, Unit>
    {
        private readonly StudentReadRepository _studentReadRepository;

        public UnregisterCommandHandlerPostProcessor(StudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;
        }

        public Task Process(UnregisterCommand request, Unit response, CancellationToken cancellationToken)
        {
            var readStudentModel = _studentReadRepository.GetBySSN(request.SSN);
            
            _studentReadRepository.Delete(readStudentModel);

            return Task.CompletedTask;
        }
    }
}