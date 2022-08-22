using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations.BOI2Db
{
    public partial class changeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.CreateTable(
                name: "AOCompanyType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOCompanyType", x => x.id);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "AOCompanyType");

           
        }
    }
}
