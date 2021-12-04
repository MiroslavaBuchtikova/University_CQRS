using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_CQRS.Persistance.Migrations.UniversityReadDb
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfEnrollments = table.Column<int>(type: "int", nullable: false),
                    FirstCourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstCourseCredits = table.Column<int>(type: "int", nullable: true),
                    FirstCourseGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondCourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondCourseCredits = table.Column<int>(type: "int", nullable: true),
                    SecondCourseGrade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
