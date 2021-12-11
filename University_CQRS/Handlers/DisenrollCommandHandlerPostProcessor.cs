
using MediatR;
using MediatR.Pipeline;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class DisenrollCommandHandlerPostProcessor : IRequestPostProcessor<DisenrollCommand, ResultDto>
    {
        private readonly StudentReadRepository _studentReadRepository;

        public DisenrollCommandHandlerPostProcessor(StudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;
        }

        public Task Process(DisenrollCommand request, ResultDto response, CancellationToken cancellationToken)
        {
            if (response.IsSuccess)
            {
                var readStudentModel = _studentReadRepository.GetBySSN(request.SSN);
                if (request.EnrollmentIndex == 0)
                {
                    readStudentModel.Course1 = null;
                    readStudentModel.Course1Grade = null;
                    readStudentModel.Course1Credits = null;
                    readStudentModel.Course1DisenrollmentComment = request.Comment;
                    readStudentModel.NumberOfCourses = readStudentModel.NumberOfCourses--;
                }

                if (request.EnrollmentIndex == 1)
                {
                    readStudentModel.Course2 = null;
                    readStudentModel.Course2Grade = null;
                    readStudentModel.Course2Credits = null;
                    readStudentModel.Course2DisenrollmentComment = request.Comment;
                    readStudentModel.NumberOfCourses = readStudentModel.NumberOfCourses--;
                }

                _studentReadRepository.Save(readStudentModel);
            }

            return Task.CompletedTask;
        }
    }
}