using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCentresCollectesDonsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Centres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    NomCentre = table.Column<string>(type: "text", nullable: false),
                    TypeCentre = table.Column<string>(type: "text", nullable: false),
                    VilleId = table.Column<long>(type: "bigint", nullable: false),
                    CreePar = table.Column<string>(type: "text", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiePar = table.Column<string>(type: "text", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collectes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCollecte = table.Column<DateOnly>(type: "date", nullable: false),
                    CentreId = table.Column<int>(type: "integer", nullable: false),
                    CreePar = table.Column<string>(type: "text", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiePar = table.Column<string>(type: "text", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collectes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collectes_Centres_CentreId",
                        column: x => x.CentreId,
                        principalTable: "Centres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DonneurId = table.Column<long>(type: "bigint", nullable: false),
                    CollecteId = table.Column<long>(type: "bigint", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    TestePositifPourMaladie = table.Column<bool>(type: "boolean", nullable: false),
                    CreePar = table.Column<string>(type: "text", nullable: true),
                    CreeLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiePar = table.Column<string>(type: "text", nullable: true),
                    ModifieLe = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dons_Collectes_CollecteId",
                        column: x => x.CollecteId,
                        principalTable: "Collectes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dons_Donneurs_DonneurId",
                        column: x => x.DonneurId,
                        principalTable: "Donneurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collectes_CentreId",
                table: "Collectes",
                column: "CentreId");

            migrationBuilder.CreateIndex(
                name: "IX_Dons_CollecteId",
                table: "Dons",
                column: "CollecteId");

            migrationBuilder.CreateIndex(
                name: "IX_Dons_DonneurId",
                table: "Dons",
                column: "DonneurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dons");

            migrationBuilder.DropTable(
                name: "Collectes");

            migrationBuilder.DropTable(
                name: "Centres");
        }
    }
}
