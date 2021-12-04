using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Context;

namespace University_CQRS.Persistance.Repositories
    {
        public sealed class CourseRepository : GenericRepository<Student>
        {
            public CourseRepository(UniversityWriteDbContext dbContext, UniversityReadDbContext dbReadContext) : base(dbContext, dbReadContext)
            {
            }

            public Course GetByName(string name)
            {
                return DbContext.Courses
                    .SingleOrDefault(x => x.Name == name);
            }
        }
    }
