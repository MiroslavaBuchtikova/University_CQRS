
using MediatR;
using MediatR.Pipeline;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class TransferHandlerPostProcessor : IRequestPostProcessor<TransferCommand, Unit>
    {
        private readonly StudentReadRepository _studentReadRepository;

        public TransferHandlerPostProcessor(StudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;
        }

        public Task Process(TransferCommand request, Unit response, CancellationToken cancellationToken)
        {
            var readStudentModel = _studentReadRepository.GetBySSN(request.SSN);;
            if (request.EnrollmentIndex == 0)
            {
                readStudentModel.Course1 = request.Course;
                readStudentModel.Course1Grade = request.Grade;
                readStudentModel.Course1DisenrollmentComment = null;
            }

            if (request.EnrollmentIndex == 1)
            {
                readStudentModel.Course2 = request.Course;
                readStudentModel.Course2Grade = request.Grade;
                readStudentModel.Course2DisenrollmentComment = null;
            }

            _studentReadRepository.Save(readStudentModel);

            return Task.CompletedTask;
        }
    }
}