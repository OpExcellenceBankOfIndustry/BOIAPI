using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class AuditableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PEPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "PEPs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "PEPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "PEPs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "IndividualWatchLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "IndividualWatchLists",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "IndividualWatchLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "IndividualWatchLists",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FEPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "FEPs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "FEPs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "FEPs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CorporateWatchLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "CorporateWatchLists",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "CorporateWatchLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastModifiedDate",
                table: "CorporateWatchLists",
                type: "datetimeoffset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PEPs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PEPs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "PEPs");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "PEPs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "IndividualWatchLists");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "IndividualWatchLists");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "IndividualWatchLists");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "IndividualWatchLists");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FEPs");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "FEPs");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "FEPs");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "FEPs");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CorporateWatchLists");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CorporateWatchLists");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "CorporateWatchLists");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "CorporateWatchLists");
        }
    }
}
