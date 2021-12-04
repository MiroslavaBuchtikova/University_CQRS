using University_CQRS.Persistance.Context;

namespace University_CQRS.Persistance.Repositories
{
    public abstract class GenericRepository<T>
    {
        protected UniversityWriteDbContext DbContext { get; }

        protected UniversityReadDbContext DbReadContext { get; }

        public GenericRepository(UniversityWriteDbContext dbContext, UniversityReadDbContext dbReadContext)
        {
            DbContext = dbContext;
            DbReadContext = dbReadContext;
        }
    }
}