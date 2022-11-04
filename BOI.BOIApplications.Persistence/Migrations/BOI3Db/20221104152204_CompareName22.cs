using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI3Db
{
    public partial class CompareName22 : Migration
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
                    objectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    objectives = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessTINResponses", x => x.id);
                });

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
                    imageHeaderN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bvnImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    imageHeaderN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NDLImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    imageHeaderN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INPImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signatureHeaderN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signatureImageN = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    imageHeaderN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ninImageN = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signatureHeaderN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    signatureImageN = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                    addressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    lastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPVCResponses", x => x.PVCId);
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
                name: "CustomerBVNResponses");

            migrationBuilder.DropTable(
                name: "CustomerDriversLicenseResponses");

            migrationBuilder.DropTable(
                name: "CustomerINTLPassportResponses");

            migrationBuilder.DropTable(
                name: "CustomerNINResponses");

            migrationBuilder.DropTable(
                name: "CustomerPVCResponses");

            migrationBuilder.DropTable(
                name: "keyPersonnelDetails");

            migrationBuilder.DropTable(
                name: "BusinessCACResponses");

            migrationBuilder.DropTable(
                name: "BusinessTINResponses");
        }
    }
}
