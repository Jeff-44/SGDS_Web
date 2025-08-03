using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCsvReferenceDataFiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VilleId",
                table: "Centres");

            migrationBuilder.AddColumn<int>(
                name: "CommuneId",
                table: "Centres",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    CreePar = table.Column<string>(type: "text", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiePar = table.Column<string>(type: "text", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Arrondissements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    DepartementId = table.Column<short>(type: "smallint", nullable: true),
                    CreePar = table.Column<string>(type: "text", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiePar = table.Column<string>(type: "text", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrondissements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrondissements_Departements_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Communes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    ArrondissementId = table.Column<int>(type: "integer", nullable: false),
                    DepartementId = table.Column<short>(type: "smallint", nullable: false),
                    MapId = table.Column<int>(type: "integer", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Population = table.Column<long>(type: "bigint", nullable: false),
                    Superficie = table.Column<int>(type: "integer", nullable: false),
                    Zoom = table.Column<int>(type: "integer", nullable: false),
                    CreePar = table.Column<string>(type: "text", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiePar = table.Column<string>(type: "text", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communes_Arrondissements_ArrondissementId",
                        column: x => x.ArrondissementId,
                        principalTable: "Arrondissements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Centres_CommuneId",
                table: "Centres",
                column: "CommuneId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrondissements_DepartementId",
                table: "Arrondissements",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Communes_ArrondissementId",
                table: "Communes",
                column: "ArrondissementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Centres_Communes_CommuneId",
                table: "Centres",
                column: "CommuneId",
                principalTable: "Communes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Centres_Communes_CommuneId",
                table: "Centres");

            migrationBuilder.DropTable(
                name: "Communes");

            migrationBuilder.DropTable(
                name: "Arrondissements");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropIndex(
                name: "IX_Centres_CommuneId",
                table: "Centres");

            migrationBuilder.DropColumn(
                name: "CommuneId",
                table: "Centres");

            migrationBuilder.AddColumn<long>(
                name: "VilleId",
                table: "Centres",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
