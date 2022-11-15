using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    public partial class thirdparty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerBVNResponses",
                columns: table => new
                {
                    BVNId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataValidation = table.Column<bool>(type: "bit", nullable: false),
                    selfieValidation = table.Column<bool>(type: "bit", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enrollmentBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enrollmentInstitution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isConsent = table.Column<bool>(type: "bit", nullable: false),
                    shouldRetrivedNin = table.Column<bool>(type: "bit", nullable: false),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBVNResponses", x => x.BVNId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDriversLicenseResponses",
                columns: table => new
                {
                    NDLId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataValidation = table.Column<bool>(type: "bit", nullable: false),
                    selfieValidation = table.Column<bool>(type: "bit", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    issuedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    expiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    stateOfIssuance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notifyWhenIdExpire = table.Column<bool>(type: "bit", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isConsent = table.Column<bool>(type: "bit", nullable: false),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDriversLicenseResponses", x => x.NDLId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerINTLPassportResponses",
                columns: table => new
                {
                    INPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataValidation = table.Column<bool>(type: "bit", nullable: false),
                    selfieValidation = table.Column<bool>(type: "bit", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    issuedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    expiredDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    stateOfIssuance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    notifyWhenIdExpire = table.Column<bool>(type: "bit", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    issuedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isConsent = table.Column<bool>(type: "bit", nullable: false),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerINTLPassportResponses", x => x.INPId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerNINResponses",
                columns: table => new
                {
                    NINId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataValidation = table.Column<bool>(type: "bit", nullable: false),
                    selfieValidation = table.Column<bool>(type: "bit", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nokState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthLGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isConsent = table.Column<bool>(type: "bit", nullable: false),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    town = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lga = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addressLine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerNINResponses", x => x.NINId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPVCResponses",
                columns: table => new
                {
                    PVCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataValidation = table.Column<bool>(type: "bit", nullable: false),
                    selfieValidation = table.Column<bool>(type: "bit", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    middleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    isConsent = table.Column<bool>(type: "bit", nullable: false),
                    businessId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requestedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPVCResponses", x => x.PVCId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerBVNResponses");

            migrationBuilder.DropTable(
                name: "CustomerDriversLicenseResponses");

            migrationBuilder.DropTable(
                name: "CustomerINTLPassportResponses");

            migrationBuilder.DropTable(
                name: "CustomerNINResponses");

            migrationBuilder.DropTable(
                name: "CustomerPVCResponses");
        }
    }
}
