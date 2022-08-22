using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class userRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BusinessAddress",
                table: "AspNetUsers",
                newName: "UserRole");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "AspNetUsers",
                newName: "BusinessAddress");

           
        }
    }
}
