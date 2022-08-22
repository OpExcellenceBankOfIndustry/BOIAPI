using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class EmailTablesfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_EmailAttachments_EmailAttachmentId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_EmailAttachmentId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "EmailAttachmentId",
                table: "Emails");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Attachment",
                table: "EmailAttachments",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AddColumn<int>(
                name: "EmailId",
                table: "EmailAttachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailAttachments_EmailId",
                table: "EmailAttachments",
                column: "EmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAttachments_Emails_EmailId",
                table: "EmailAttachments",
                column: "EmailId",
                principalTable: "Emails",
                principalColumn: "EmailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailAttachments_Emails_EmailId",
                table: "EmailAttachments");

            migrationBuilder.DropIndex(
                name: "IX_EmailAttachments_EmailId",
                table: "EmailAttachments");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "EmailAttachments");

            migrationBuilder.AddColumn<int>(
                name: "EmailAttachmentId",
                table: "Emails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Attachment",
                table: "EmailAttachments",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmailAttachmentId",
                table: "Emails",
                column: "EmailAttachmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_EmailAttachments_EmailAttachmentId",
                table: "Emails",
                column: "EmailAttachmentId",
                principalTable: "EmailAttachments",
                principalColumn: "EmailAttachmentId");
        }
    }
}
