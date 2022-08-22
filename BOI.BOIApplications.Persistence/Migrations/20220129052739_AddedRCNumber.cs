using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class AddedRCNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DefaultPassword",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RCNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RCNumber",
                table: "AspNetUsers");
        }
    }
}
