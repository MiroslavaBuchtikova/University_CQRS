
using University_CQRS.Persistance.Context;

namespace University_CQRS.Persistance.Repositories
{
    public sealed class CourseRepository : GenericRepository<Student>
    {
        public CourseRepository(UniversityDbContext dbContext) : base(dbContext)
        {
        }

        public Course GetByName(string name)
        {
            return DbContext.Courses
                .SingleOrDefault(x => x.Name == name);
        }
    }
    }
