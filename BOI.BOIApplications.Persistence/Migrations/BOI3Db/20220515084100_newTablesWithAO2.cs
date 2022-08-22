using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    public partial class newTablesWithAO2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesRelationships",
                table: "EmployeesRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyBOIDiscovers",
                table: "CompanyBOIDiscovers");

            migrationBuilder.RenameTable(
                name: "JobTitles",
                newName: "AOJobTitles");

            migrationBuilder.RenameTable(
                name: "EmployeesRelationships",
                newName: "AOEmployeesRelationships");

            migrationBuilder.RenameTable(
                name: "CompanyBOIDiscovers",
                newName: "AOCompanyBOIDiscovers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AOJobTitles",
                table: "AOJobTitles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AOEmployeesRelationships",
                table: "AOEmployeesRelationships",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AOCompanyBOIDiscovers",
                table: "AOCompanyBOIDiscovers",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AOJobTitles",
                table: "AOJobTitles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AOEmployeesRelationships",
                table: "AOEmployeesRelationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AOCompanyBOIDiscovers",
                table: "AOCompanyBOIDiscovers");

            migrationBuilder.RenameTable(
                name: "AOJobTitles",
                newName: "JobTitles");

            migrationBuilder.RenameTable(
                name: "AOEmployeesRelationships",
                newName: "EmployeesRelationships");

            migrationBuilder.RenameTable(
                name: "AOCompanyBOIDiscovers",
                newName: "CompanyBOIDiscovers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobTitles",
                table: "JobTitles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesRelationships",
                table: "EmployeesRelationships",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyBOIDiscovers",
                table: "CompanyBOIDiscovers",
                column: "id");
        }
    }
}
