using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_CQRS.Persistance.Migrations
{
    public partial class AddReadStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReadStudents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfCourses = table.Column<int>(type: "int", nullable: false),
                    Course1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course1Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course1DisenrollmentComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course1Credits = table.Column<int>(type: "int", nullable: true),
                    Course2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course2Grade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course2DisenrollmentComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Course2Credits = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReadStudents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReadStudents");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "Students");
        }
    }
}
