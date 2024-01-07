using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionBibliotheque.Migrations
{
    /// <inheritdoc />
    public partial class empruntAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empruntes",
                columns: table => new
                {
                    EmprunteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateRetourPrevue = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateRetourReelle = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateEmprunte = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LivreId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserCIN = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empruntes", x => x.EmprunteId);
                    table.ForeignKey(
                        name: "FK_Empruntes_Livres_LivreId",
                        column: x => x.LivreId,
                        principalTable: "Livres",
                        principalColumn: "LivreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empruntes_Users_UserCIN",
                        column: x => x.UserCIN,
                        principalTable: "Users",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empruntes_LivreId",
                table: "Empruntes",
                column: "LivreId");

            migrationBuilder.CreateIndex(
                name: "IX_Empruntes_UserCIN",
                table: "Empruntes",
                column: "UserCIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empruntes");
        }
    }
}
