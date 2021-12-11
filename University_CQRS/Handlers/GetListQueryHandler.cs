
using MediatR;
using University_CQRS.Mapping;
using University_CQRS.Persistance.Repositories;
using University_CQRS.Queries;

namespace University_CQRS.Handlers
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<StudentDto>>
    {
        private readonly StudentReadRepository _studentRepository;

        public GetListQueryHandler(StudentReadRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var students = _studentRepository.GetList(request.CourseName, request.NumberOfCourses).ToList();

            return students;
        }
    }
}