using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class filepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "AOCompanyInformations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "AOCompanyInformations");

            
        }
    }
}
