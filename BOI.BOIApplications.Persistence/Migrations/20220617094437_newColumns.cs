using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class newColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoardResolution",
                table: "AORegulatoryInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memart",
                table: "AORegulatoryInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificateOfIncorporationRegistration",
                table: "AOOwnershipInformationCooperate",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardResolution",
                table: "AORegulatoryInformation");

            migrationBuilder.DropColumn(
                name: "Memart",
                table: "AORegulatoryInformation");

            migrationBuilder.DropColumn(
                name: "CertificateOfIncorporationRegistration",
                table: "AOOwnershipInformationCooperate");
        }
    }
}
