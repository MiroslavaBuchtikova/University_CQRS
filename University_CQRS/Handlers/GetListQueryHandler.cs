
using MediatR;
using University_CQRS.Mapping;
using University_CQRS.Persistance.Repositories;
using University_CQRS.Queries;

namespace University_CQRS.Handlers
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<StudentDto>>
    {
        private readonly StudentReadRepository _studentReadRepository;

        public GetListQueryHandler(StudentReadRepository studentReadRepository)
        {
            _studentReadRepository = studentReadRepository;
        }

        public async Task<List<StudentDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var students = _studentReadRepository.GetList(request.CourseName, request.NumberOfCourses);
            var dtos = students.Map();

            return dtos;
        }
    }
}