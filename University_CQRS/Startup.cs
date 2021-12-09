using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using University_CQRS.Contracts.Entities.Students;
using University_CQRS.Persistance.Context;


namespace University_CQRS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                 .AddControllersAsServices();
            services.AddControllers();
            services.AddRepositories()
                    .AddMediatR(Assembly.GetExecutingAssembly());

            var connectionString = Configuration.GetConnectionString("database");
            services.AddDbContextPool<UniversityWriteDbContext>(option =>
            option.UseSqlServer(connectionString,
             contextOptions =>
             {
                 contextOptions.MigrationsAssembly(typeof(UniversityWriteDbContext).Assembly.FullName);
             })
            );

            var readConnectionString = Configuration.GetConnectionString("readDatabase");
            services.AddDbContextPool<UniversityReadDbContext>(option =>
            option.UseSqlServer(readConnectionString,
             contextOptions =>
             {
                 contextOptions.MigrationsAssembly(typeof(UniversityReadDbContext).Assembly.FullName);
             })
            );
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var runMigration = true;
            if (runMigration)
            {
                using var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();
                using var context = serviceScope.ServiceProvider.GetService<UniversityWriteDbContext>();
                context.Database.Migrate();
                SeedDatabase(context);
            }
        }
        private static void SeedDatabase(UniversityWriteDbContext context)
        {
            var courses = new List<Course>()
            {
                new Course()
                {
                   Name = "Calculus",
                   Credits = 3
                },
                  new Course()
                {
                   Name = "Chemistry",
                   Credits = 3
                },
                    new Course()
                {
                   Name = "Composition",
                   Credits = 3
                },
                      new Course()
                {
                   Name = "Literature",
                   Credits = 4
                },
                        new Course()
                {
                   Name = "Trigonometry",
                   Credits = 4
                },
                          new Course()
                {
                   Name = "Microeconomics",
                   Credits = 3
                },
                            new Course()
                {
                   Name = "Macroeconomics",
                   Credits = 3
                },
            };

            if (!context.Courses.Any())
            {
                context.Courses.AddRange(courses);
                context.SaveChanges();
            }
        }
    }
}
