using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    public partial class new2Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "CustomerPVCResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "CustomerPVCResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "CustomerNINResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "CustomerNINResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "CustomerINTLPassportResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "CustomerINTLPassportResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "CustomerDriversLicenseResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "CustomerDriversLicenseResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "BusinessTINResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "BusinessTINResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "BusinessCACResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "BusinessCACResponses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "CustomerPVCResponses");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "CustomerPVCResponses");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "CustomerNINResponses");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "CustomerNINResponses");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "CustomerINTLPassportResponses");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "CustomerINTLPassportResponses");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "CustomerDriversLicenseResponses");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "CustomerDriversLicenseResponses");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "BusinessTINResponses");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "BusinessTINResponses");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "BusinessCACResponses");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "BusinessCACResponses");
        }
    }
}
