using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    public partial class imageParts5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "signatureImage",
                table: "CustomerNINResponses",
                newName: "signatureImageN");

            migrationBuilder.RenameColumn(
                name: "signatureHeader",
                table: "CustomerNINResponses",
                newName: "signatureHeaderN");

            migrationBuilder.RenameColumn(
                name: "ninImage",
                table: "CustomerNINResponses",
                newName: "ninImageN");

            migrationBuilder.RenameColumn(
                name: "imageHeader",
                table: "CustomerNINResponses",
                newName: "imageHeaderN");

            migrationBuilder.RenameColumn(
                name: "signatureImage",
                table: "CustomerINTLPassportResponses",
                newName: "signatureImageN");

            migrationBuilder.RenameColumn(
                name: "signatureHeader",
                table: "CustomerINTLPassportResponses",
                newName: "signatureHeaderN");

            migrationBuilder.RenameColumn(
                name: "imageHeader",
                table: "CustomerINTLPassportResponses",
                newName: "imageHeaderN");

            migrationBuilder.RenameColumn(
                name: "imageHeader",
                table: "CustomerDriversLicenseResponses",
                newName: "imageHeaderN");

            migrationBuilder.RenameColumn(
                name: "imageHeader",
                table: "CustomerBVNResponses",
                newName: "imageHeaderN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "signatureImageN",
                table: "CustomerNINResponses",
                newName: "signatureImage");

            migrationBuilder.RenameColumn(
                name: "signatureHeaderN",
                table: "CustomerNINResponses",
                newName: "signatureHeader");

            migrationBuilder.RenameColumn(
                name: "ninImageN",
                table: "CustomerNINResponses",
                newName: "ninImage");

            migrationBuilder.RenameColumn(
                name: "imageHeaderN",
                table: "CustomerNINResponses",
                newName: "imageHeader");

            migrationBuilder.RenameColumn(
                name: "signatureImageN",
                table: "CustomerINTLPassportResponses",
                newName: "signatureImage");

            migrationBuilder.RenameColumn(
                name: "signatureHeaderN",
                table: "CustomerINTLPassportResponses",
                newName: "signatureHeader");

            migrationBuilder.RenameColumn(
                name: "imageHeaderN",
                table: "CustomerINTLPassportResponses",
                newName: "imageHeader");

            migrationBuilder.RenameColumn(
                name: "imageHeaderN",
                table: "CustomerDriversLicenseResponses",
                newName: "imageHeader");

            migrationBuilder.RenameColumn(
                name: "imageHeaderN",
                table: "CustomerBVNResponses",
                newName: "imageHeader");
        }
    }
}
