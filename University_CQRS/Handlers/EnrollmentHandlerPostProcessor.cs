
using MediatR;
using MediatR.Pipeline;
using University_CQRS.Commands;

using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class EnrollmentHandlerPostProcessor : IRequestPostProcessor<EnrollCommand, Unit>
    {
        private readonly StudentReadRepository _studentReadRepository;

        public EnrollmentHandlerPostProcessor(StudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;
        }

        public Task Process(EnrollCommand request, Unit response, CancellationToken cancellationToken)
        {
            var readStudentModel = _studentReadRepository.GetBySSN(request.SSN);

            if (readStudentModel.Course1 == null)
            {
                readStudentModel.Course1 = request.Course;
                readStudentModel.Course1Grade = request.Grade;
                readStudentModel.Course1DisenrollmentComment = null;
                readStudentModel.NumberOfCourses = readStudentModel.NumberOfCourses++;
            }

            if (readStudentModel.Course2 == null)
            {
                readStudentModel.Course2 = request.Course;
                readStudentModel.Course2Grade = request.Grade;
                readStudentModel.Course2DisenrollmentComment = null;
                readStudentModel.NumberOfCourses = readStudentModel.NumberOfCourses++;
            }

            _studentReadRepository.Save(readStudentModel);

            return Task.CompletedTask;
        }
    }
}