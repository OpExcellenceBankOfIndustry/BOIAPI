using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class pepfepandwatchlists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorporateWatchLists",
                columns: table => new
                {
                    CorporateWatchListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateWatchLists", x => x.CorporateWatchListId);
                });

            migrationBuilder.CreateTable(
                name: "FEPs",
                columns: table => new
                {
                    FepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FepBvn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FepPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FepOrganisation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEPs", x => x.FepId);
                });

            migrationBuilder.CreateTable(
                name: "IndividualWatchLists",
                columns: table => new
                {
                    IndividualWatchListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndividualBvn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndividualName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualWatchLists", x => x.IndividualWatchListId);
                });

            migrationBuilder.CreateTable(
                name: "PEPs",
                columns: table => new
                {
                    PepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PepBvn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPoliticalParty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPoliticalPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastPoliticalParty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastPoliticalPosition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEPs", x => x.PepId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateWatchLists");

            migrationBuilder.DropTable(
                name: "FEPs");

            migrationBuilder.DropTable(
                name: "IndividualWatchLists");

            migrationBuilder.DropTable(
                name: "PEPs");
        }
    }
}
