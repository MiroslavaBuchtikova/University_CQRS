
using MediatR;
using University_CQRS.Dtos;

namespace University_CQRS.Commands
{
    public class GetListQuery : IRequest<List<StudentDto>>
    {
        public string EnrolledIn { get; }

        public GetListQuery(string enrolledIn)
        {
            EnrolledIn = enrolledIn;
        }
    }
}
