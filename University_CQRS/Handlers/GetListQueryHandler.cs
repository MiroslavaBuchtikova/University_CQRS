
using MediatR;
using University_CQRS.Commands;
using University_CQRS.Dtos;
using University_CQRS.Mapping;
using University_CQRS.Persistance.Repositories;

namespace University_CQRS.Handlers
{
    public class GetListQueryHandler : IRequestHandler<GetListQuery, List<StudentDto>>
    {
        private readonly StudentRepository _studentRepository;

        public GetListQueryHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
        {
            var students = _studentRepository.GetList(request.EnrolledIn);
            var dtos = students.Map();

            return dtos;
        }
    }
}