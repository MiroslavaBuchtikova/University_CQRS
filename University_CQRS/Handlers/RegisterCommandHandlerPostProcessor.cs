
using MediatR;
using MediatR.Pipeline;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class RegisterCommandHandlerPostProcessor : IRequestPostProcessor<RegisterCommand, Unit>
    {
        private readonly StudentReadRepository _studentReadRepository;

        public RegisterCommandHandlerPostProcessor(StudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;
        }

        public Task Process(RegisterCommand request, Unit response, CancellationToken cancellationToken)
        {
            var readStudentModel = new ReadStudent
            {
                SSN = request.SSN,
                Name = request.Name,
                Email = request.Email,
                Course1 = request.Course1,
                Course1Grade = request.Course1Grade,
                Course2 = request.Course2,
                Course2Grade = request.Course2Grade,
            };
            var numberOfCourses = 0;

            if(request.Course1 != null)
            {
                numberOfCourses++;
            }
            if (request.Course2 != null)
            {
                numberOfCourses++;
            }

            readStudentModel.NumberOfCourses = numberOfCourses;

            _studentReadRepository.Save(readStudentModel);

            return Task.CompletedTask;
        }
    }
}