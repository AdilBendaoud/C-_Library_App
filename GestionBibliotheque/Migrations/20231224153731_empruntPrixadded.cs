using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionBibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class empruntPrixadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrixPaye",
                table: "Empruntes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrixPaye",
                table: "Empruntes");
        }
    }
}
