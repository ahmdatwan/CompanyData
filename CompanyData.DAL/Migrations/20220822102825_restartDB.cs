using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyData.DAL.Migrations
{
    public partial class restartDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 1, "C5.302", "Frontend" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 2, null, "Backend" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[] { 3, null, "Quality Control" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Job", "Name", "Salary" },
                values: new object[] { 1, 2, "Intern", "Ahmed Amr", 3000.0 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Job", "Name", "Salary" },
                values: new object[] { 2, 2, "Project Lead", "Ahmed Mostafa", 0.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
