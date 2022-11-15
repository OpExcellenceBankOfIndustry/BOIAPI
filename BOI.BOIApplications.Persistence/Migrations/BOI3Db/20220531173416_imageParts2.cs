using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    public partial class imageParts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ninImage",
                table: "CustomerINTLPassportResponses",
                newName: "INPImage");

            migrationBuilder.RenameColumn(
                name: "ninImage",
                table: "CustomerDriversLicenseResponses",
                newName: "NDLImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "INPImage",
                table: "CustomerINTLPassportResponses",
                newName: "ninImage");

            migrationBuilder.RenameColumn(
                name: "NDLImage",
                table: "CustomerDriversLicenseResponses",
                newName: "ninImage");
        }
    }
}
