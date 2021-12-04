using Microsoft.EntityFrameworkCore;
using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Context;

using University_CQRS.Persistance.Mapping;

namespace University_CQRS.Persistance.Repositories
{
    public sealed class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(UniversityWriteDbContext dbContext, UniversityReadDbContext dbReadContext) : base(dbContext, dbReadContext)
        {
        }

        public Student GetById(long id)
        {
            return DbContext.Students?.Include(x => x.Enrollments)
                .ThenInclude(x => x.Course).FirstOrDefault(w => w.Id == id);
        }
        public async Task SaveAsync(Student student)
        {

            var strategy = DbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await DbContext.Database.BeginTransactionAsync();

                try
                {
                    DbContext.Update(student);
                    DbReadContext.Update(student.Map());

                    DbContext.SaveChanges();
                    DbReadContext.SaveChanges();
                    DbContext.Database.CommitTransaction();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    DbContext.Database.RollbackTransaction();
                }
                catch (Exception e)
                {
                    DbContext.Database.RollbackTransaction();
                    throw;
                }
            });

        }

        public async void Delete(Student student)
        {
            var strategy = DbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                await DbContext.Database.BeginTransactionAsync();

                try
                {
                    DbContext.Remove(student);
                    var aggregatedStudent = DbReadContext.Students?.SingleOrDefault(x => x.Id == student.Id);
                    DbReadContext.Remove(aggregatedStudent);
                    DbContext.SaveChanges();
                    DbReadContext.SaveChanges();
                    DbContext.Database.CommitTransaction();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    DbContext.Database.RollbackTransaction();
                }
                catch (Exception e)
                {
                    DbContext.Database.RollbackTransaction();
                    throw;
                }
            });


        }
    }
}
