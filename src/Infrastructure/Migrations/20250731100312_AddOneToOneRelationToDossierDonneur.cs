using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOneRelationToDossierDonneur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dossiers_DonneurId",
                table: "Dossiers");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_DonneurId",
                table: "Dossiers",
                column: "DonneurId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dossiers_DonneurId",
                table: "Dossiers");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_DonneurId",
                table: "Dossiers",
                column: "DonneurId");
        }
    }
}
