using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class initialmigartion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID");
                });

            migrationBuilder.CreateTable(
                name: "LGAs",
                columns: table => new
                {
                    LGAId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LGAName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGAs", x => x.LGAId);
                    table.ForeignKey(
                        name: "FK_LGAs_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_LGAs_LGAId",
                        column: x => x.LGAId,
                        principalTable: "LGAs",
                        principalColumn: "LGAId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_LGAId",
                table: "Cities",
                column: "LGAId");

            migrationBuilder.CreateIndex(
                name: "IX_LGAs_StateId",
                table: "LGAs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryID",
                table: "States",
                column: "CountryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "LGAs");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
