using MediatR.Pipeline;
using University_CQRS.Commands;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class UnregisterCommandHandlerPostProcessor : IRequestPostProcessor<UnregisterCommand, ResultDto>
    {
        private readonly StudentReadRepository _studentReadRepository;

        public UnregisterCommandHandlerPostProcessor(StudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;
        }

        public Task Process(UnregisterCommand request, ResultDto response, CancellationToken cancellationToken)
        {
            if (response.IsSuccess)
            {
                var readStudentModel = _studentReadRepository.GetBySSN(request.SSN);

                _studentReadRepository.Delete(readStudentModel);
            }

            return Task.CompletedTask;
        }
    }
}