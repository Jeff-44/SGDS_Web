using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDossier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateNaissance",
                table: "PersonneDeContact",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateNaissance",
                table: "Donneurs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Donneurs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstEligible",
                table: "Donneurs",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EstRegulier",
                table: "Donneurs",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Raison",
                table: "Donneurs",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dossiers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonneurId = table.Column<long>(type: "bigint", nullable: false),
                    MaladieChronique = table.Column<bool>(type: "boolean", nullable: false),
                    DetailsMaladieChronique = table.Column<string>(type: "text", nullable: true),
                    EstAnemie = table.Column<bool>(type: "boolean", nullable: false),
                    EstEnceinte = table.Column<bool>(type: "boolean", nullable: false),
                    InfectionRecente = table.Column<bool>(type: "boolean", nullable: false),
                    DateInfectionRecente = table.Column<DateOnly>(type: "date", nullable: true),
                    PriseDeMedicamentsActuel = table.Column<string>(type: "text", nullable: true),
                    Poids = table.Column<float>(type: "real", nullable: false),
                    CreePar = table.Column<string>(type: "text", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiePar = table.Column<string>(type: "text", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dossiers_Donneurs_DonneurId",
                        column: x => x.DonneurId,
                        principalTable: "Donneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_DonneurId",
                table: "Dossiers",
                column: "DonneurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dossiers");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Donneurs");

            migrationBuilder.DropColumn(
                name: "EstEligible",
                table: "Donneurs");

            migrationBuilder.DropColumn(
                name: "EstRegulier",
                table: "Donneurs");

            migrationBuilder.DropColumn(
                name: "Raison",
                table: "Donneurs");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateNaissance",
                table: "PersonneDeContact",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateNaissance",
                table: "Donneurs",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
