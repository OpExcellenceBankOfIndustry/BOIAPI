using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class EmailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailAttachments",
                columns: table => new
                {
                    EmailAttachmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAttachments", x => x.EmailAttachmentId);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    EmailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToRecipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CcRecipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BccRecipient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHtml = table.Column<bool>(type: "bit", nullable: false),
                    Channel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateLogged = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Response = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Sent = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false),
                    HasAlternateView = table.Column<bool>(type: "bit", nullable: false),
                    SendDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SendAndReply = table.Column<bool>(type: "bit", nullable: false),
                    EmailAttachmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.EmailId);
                    table.ForeignKey(
                        name: "FK_Emails_EmailAttachments_EmailAttachmentId",
                        column: x => x.EmailAttachmentId,
                        principalTable: "EmailAttachments",
                        principalColumn: "EmailAttachmentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emails_EmailAttachmentId",
                table: "Emails",
                column: "EmailAttachmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "EmailAttachments");
        }
    }
}
