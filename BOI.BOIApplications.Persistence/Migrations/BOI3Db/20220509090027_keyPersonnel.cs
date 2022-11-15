using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    public partial class keyPersonnel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessCACResponses",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isConsent = table.Column<bool>(type: "bit", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    searchTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    jtbTin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    taxOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    typeOfEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registrationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    websiteEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    headOfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    objectives = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessCACResponses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessTINResponses",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isConsent = table.Column<bool>(type: "bit", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    searchTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    jtbTin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    taxOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    typeOfEntity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registrationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    websiteEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    branchAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    headOfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    objectives = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTINResponses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "keyPersonnelDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    requestedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessCACResponseid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BusinessTINResponseid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_keyPersonnelDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_keyPersonnelDetails_BusinessCACResponses_BusinessCACResponseid",
                        column: x => x.BusinessCACResponseid,
                        principalTable: "BusinessCACResponses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_keyPersonnelDetails_BusinessTINResponses_BusinessTINResponseid",
                        column: x => x.BusinessTINResponseid,
                        principalTable: "BusinessTINResponses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_keyPersonnelDetails_BusinessCACResponseid",
                table: "keyPersonnelDetails",
                column: "BusinessCACResponseid");

            migrationBuilder.CreateIndex(
                name: "IX_keyPersonnelDetails_BusinessTINResponseid",
                table: "keyPersonnelDetails",
                column: "BusinessTINResponseid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "keyPersonnelDetails");

            migrationBuilder.DropTable(
                name: "BusinessCACResponses");

            migrationBuilder.DropTable(
                name: "BusinessTINResponses");
        }
    }
}
