
using MediatR;

namespace University_CQRS.Queries
{
    public class GetListQuery : IRequest<List<StudentDto>>
    {
        public string EnrolledIn { get; }

        public int? NumberOfCourses { get; }

        public GetListQuery(string enrolledIn, int? numberOfCourses)
        {
            EnrolledIn = enrolledIn;
            NumberOfCourses = numberOfCourses;
        }
    }
}
