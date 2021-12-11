using Microsoft.EntityFrameworkCore;
using University_CQRS.Persistance.Context;

namespace University_CQRS.Persistance.Repositories
{
    public sealed class StudentReadRepository : GenericRepository<Student>
    {
        public StudentReadRepository(UniversityDbContext dbContext) : base(dbContext)
        {
        }

        public ReadStudent GetBySSN(string ssn)
        {
            return DbContext.ReadStudents
            .FirstOrDefault(w => w.SSN == ssn);
        }

        public IReadOnlyList<ReadStudent> GetList(string courseName, int? numberOfCourses)
        {
            var result = DbContext.ReadStudents
            .ToList();

            if (!string.IsNullOrWhiteSpace(courseName))
            {
                result = result.Where(x => x.Course1 == courseName || x.Course2 == courseName).ToList();
            }

            if (numberOfCourses != null)
            {
                result = result.Where(x => x.NumberOfCourses == numberOfCourses).ToList();
            }


            return result;
        }

        public void Save(ReadStudent student)
        {
            DbContext.ReadStudents.Update(student);
            DbContext.SaveChanges();
        }

        public void Delete(ReadStudent student)
        {
            DbContext.ReadStudents.Remove(student);
            DbContext.SaveChanges();
        }
    }
}
