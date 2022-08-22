using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    public partial class newTablesWithAO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesRelationship");

            migrationBuilder.CreateTable(
                name: "EmployeesRelationships",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesRelationships", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesRelationships");

            migrationBuilder.CreateTable(
                name: "EmployeesRelationship",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesRelationship", x => x.id);
                });
        }
    }
}
