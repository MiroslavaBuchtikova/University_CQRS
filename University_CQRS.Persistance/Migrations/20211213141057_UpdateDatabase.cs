using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_CQRS.Persistance.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadStudents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReadStudents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course1Credits = table.Column<int>(type: "int", nullable: true),
                    Course1DisenrollmentComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course1Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course2Credits = table.Column<int>(type: "int", nullable: true),
                    Course2DisenrollmentComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course2Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfCourses = table.Column<int>(type: "int", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadStudents", x => x.Id);
                });
        }
    }
}
