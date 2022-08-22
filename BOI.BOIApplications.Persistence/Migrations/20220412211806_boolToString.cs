using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BOI.BOIApplications.Persistence.Migrations
{
    public partial class boolToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_LGAs_LGAId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_LGAs_States_StateId",
                table: "LGAs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LGAs",
                table: "LGAs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "LGAs",
                newName: "LGA");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameIndex(
                name: "IX_LGAs_StateId",
                table: "LGA",
                newName: "IX_LGA_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_LGAId",
                table: "City",
                newName: "IX_City_LGAId");

            migrationBuilder.AlterColumn<string>(
                name: "ContestedPoliticalOffice",
                table: "AOSoleProprietorship",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "AnyPoliticalAffilationWithAPoliticalOfficeHolder",
                table: "AOSoleProprietorship",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "AnyRelationshipWithAnyBOIEmployeeOrAnyOfItsDirectors",
                table: "AORelatedPartyInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "PresentThreatenedLitigationWithThirdParty",
                table: "AORegulatoryInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizationMembership",
                table: "AORegulatoryInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "IsYourCompanyQuotedOnAnyStockExchange",
                table: "AORegulatoryInformation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "ContestedPoliticalOffice",
                table: "AOOwnershipInformationIndividual",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "AnyPoliticalAffilationWithAPoliticalOfficeHolder",
                table: "AOOwnershipInformationIndividual",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyOwnsBusinessPremises",
                table: "AOCompanyInformations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "LGAId",
                table: "City",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LGA",
                table: "LGA",
                column: "LGAId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityId");

            migrationBuilder.CreateTable(
                name: "AOAnnualTurnover",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnnualTurnover = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOAnnualTurnover", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOCompanyType",
                columns: table => new
                {
                    company_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOCompanyType", x => x.company_type_id);
                });

            migrationBuilder.CreateTable(
                name: "AOHighestEducationalQualification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HighestEducationalQualification = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOHighestEducationalQualification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOIdentificationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentificationType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOIdentificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOMaritalStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOMaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOStakeholderCapacity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StakeholderCapacity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOStakeholderCapacity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AOTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AOTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    bank_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.bank_id);
                });

            migrationBuilder.CreateTable(
                name: "MCCollateralPledgedExistingLoans",
                columns: table => new
                {
                    collateral_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collateral_pledged = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCCollateralPledgedExistingLoans", x => x.collateral_id);
                });

            migrationBuilder.CreateTable(
                name: "MCCollateralTypeProposedCollateral",
                columns: table => new
                {
                    collateral_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collateral_type_proposed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCCollateralTypeProposedCollateral", x => x.collateral_id);
                });

            migrationBuilder.CreateTable(
                name: "MCIndustrySector",
                columns: table => new
                {
                    ind_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sector = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCIndustrySector", x => x.ind_id);
                });

            migrationBuilder.CreateTable(
                name: "MCLoanClass",
                columns: table => new
                {
                    loan_class_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loan_class = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCLoanClass", x => x.loan_class_id);
                });

            migrationBuilder.CreateTable(
                name: "MCLoanPurpose",
                columns: table => new
                {
                    loan_purpose_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loan_purpose = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCLoanPurpose", x => x.loan_purpose_id);
                });

            migrationBuilder.CreateTable(
                name: "MCLoanType",
                columns: table => new
                {
                    loan_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loan_type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCLoanType", x => x.loan_type_id);
                });

            migrationBuilder.CreateTable(
                name: "MCMoratorium",
                columns: table => new
                {
                    moratorium_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    moratorium = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCMoratorium", x => x.moratorium_id);
                });

            migrationBuilder.CreateTable(
                name: "MCProducts",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCProducts", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "MCRepaymentPlan",
                columns: table => new
                {
                    repayment_plan_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    repayment_plan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCRepaymentPlan", x => x.repayment_plan_id);
                });

            migrationBuilder.CreateTable(
                name: "MCSourceOfFunds",
                columns: table => new
                {
                    source_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source_funds = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MCSourceOfFunds", x => x.source_id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_LGA_LGAId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_LGA_States_StateId",
                table: "LGA");

            migrationBuilder.DropTable(
                name: "AOAnnualTurnover");

            migrationBuilder.DropTable(
                name: "AOCompanyType");

            migrationBuilder.DropTable(
                name: "AOHighestEducationalQualification");

            migrationBuilder.DropTable(
                name: "AOIdentificationType");

            migrationBuilder.DropTable(
                name: "AOMaritalStatus");

            migrationBuilder.DropTable(
                name: "AOStakeholderCapacity");

            migrationBuilder.DropTable(
                name: "AOTitle");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "MCCollateralPledgedExistingLoans");

            migrationBuilder.DropTable(
                name: "MCCollateralTypeProposedCollateral");

            migrationBuilder.DropTable(
                name: "MCIndustrySector");

            migrationBuilder.DropTable(
                name: "MCLoanClass");

            migrationBuilder.DropTable(
                name: "MCLoanPurpose");

            migrationBuilder.DropTable(
                name: "MCLoanType");

            migrationBuilder.DropTable(
                name: "MCMoratorium");

            migrationBuilder.DropTable(
                name: "MCProducts");

            migrationBuilder.DropTable(
                name: "MCRepaymentPlan");

            migrationBuilder.DropTable(
                name: "MCSourceOfFunds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LGA",
                table: "LGA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "LGA",
                newName: "LGAs");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameIndex(
                name: "IX_LGA_StateId",
                table: "LGAs",
                newName: "IX_LGAs_StateId");

            migrationBuilder.RenameIndex(
                name: "IX_City_LGAId",
                table: "Cities",
                newName: "IX_Cities_LGAId");

            migrationBuilder.AlterColumn<bool>(
                name: "ContestedPoliticalOffice",
                table: "AOSoleProprietorship",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AnyPoliticalAffilationWithAPoliticalOfficeHolder",
                table: "AOSoleProprietorship",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AnyRelationshipWithAnyBOIEmployeeOrAnyOfItsDirectors",
                table: "AORelatedPartyInformation",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PresentThreatenedLitigationWithThirdParty",
                table: "AORegulatoryInformation",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "OrganizationMembership",
                table: "AORegulatoryInformation",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsYourCompanyQuotedOnAnyStockExchange",
                table: "AORegulatoryInformation",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ContestedPoliticalOffice",
                table: "AOOwnershipInformationIndividual",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AnyPoliticalAffilationWithAPoliticalOfficeHolder",
                table: "AOOwnershipInformationIndividual",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CompanyOwnsBusinessPremises",
                table: "AOCompanyInformations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LGAId",
                table: "Cities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LGAs",
                table: "LGAs",
                column: "LGAId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_LGAs_LGAId",
                table: "Cities",
                column: "LGAId",
                principalTable: "LGAs",
                principalColumn: "LGAId");

            migrationBuilder.AddForeignKey(
                name: "FK_LGAs_States_StateId",
                table: "LGAs",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId");
        }
    }
}
