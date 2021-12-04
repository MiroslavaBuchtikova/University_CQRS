
using MediatR;
using University_CQRS.Commands;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<StudentDto>>
    {
        private readonly AggregatedStudentRepository _studentRepository;

        public GetListQueryHandler(AggregatedStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var students = _studentRepository.GetList(request.EnrolledIn, request.NumberOfCourses).ToList();

            return students;
        }
    }
}