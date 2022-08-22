using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class boolToString3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_LGA_LGAId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_LGA_States_StateId",
                table: "LGA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LGA",
                table: "LGA");

            migrationBuilder.RenameTable(
                name: "LGA",
                newName: "LocalGovtArea");

            migrationBuilder.RenameIndex(
                name: "IX_LGA_StateId",
                table: "LocalGovtArea",
                newName: "IX_LocalGovtArea_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocalGovtArea",
                table: "LocalGovtArea",
                column: "LGAId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_LocalGovtArea_LGAId",
                table: "City",
                column: "LGAId",
                principalTable: "LocalGovtArea",
                principalColumn: "LGAId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocalGovtArea_States_StateId",
                table: "LocalGovtArea",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_LocalGovtArea_LGAId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_LocalGovtArea_States_StateId",
                table: "LocalGovtArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocalGovtArea",
                table: "LocalGovtArea");

            migrationBuilder.RenameTable(
                name: "LocalGovtArea",
                newName: "LGA");

            migrationBuilder.RenameIndex(
                name: "IX_LocalGovtArea_StateId",
                table: "LGA",
                newName: "IX_LGA_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LGA",
                table: "LGA",
                column: "LGAId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_LGA_LGAId",
                table: "City",
                column: "LGAId",
                principalTable: "LGA",
                principalColumn: "LGAId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LGA_States_StateId",
                table: "LGA",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId");
        }
    }
}
