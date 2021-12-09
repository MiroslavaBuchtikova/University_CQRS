using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Context;

namespace University_CQRS.Persistance.Repositories
{
    public sealed class StudentReadRepository : GenericRepository<StudentAggregate>
    {
        public StudentReadRepository(UniversityWriteDbContext dbContext, UniversityReadDbContext dbReadContext) : base(dbContext, dbReadContext)
        {
        }

        public IReadOnlyList<StudentDto> GetList(string enrolledIn, int? numberOfCourses)
        {
            var students = DbReadContext.Students.ToList();

            if(!string.IsNullOrEmpty(enrolledIn))
            {
                students?.Where(w => w.FirstCourseName == enrolledIn || w.SecondCourseName == enrolledIn);
            }
            if(numberOfCourses != null)
            {
                students?.Where(w=>w.NumberOfEnrollments == numberOfCourses);
            }

           var result = students.Select(x => new StudentDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Course1 = x.FirstCourseName,
                Course1Credits = x.FirstCourseCredits,
                Course1Grade = x.FirstCourseGrade,
                Course2 = x.SecondCourseName,
                Course2Credits = x.SecondCourseCredits,
                Course2Grade = x.SecondCourseGrade

            }).ToList();
            return result;
        }
    }
}
