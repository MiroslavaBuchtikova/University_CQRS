using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace University_CQRS.Persistance.Context;

public class UniversityReadDbContext : DbContext
{
    public virtual DbSet<StudentAggregate> Students { get; set; }
    public UniversityReadDbContext(DbContextOptions<UniversityReadDbContext> options) :
        base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
