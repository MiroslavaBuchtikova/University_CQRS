using University_CQRS.Persistance.Context;

namespace University_CQRS.Persistance.Repositories
{
    public abstract class GenericRepository<T>
    {
        protected UniversityDbContext DbContext { get; }

        public GenericRepository(UniversityDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}