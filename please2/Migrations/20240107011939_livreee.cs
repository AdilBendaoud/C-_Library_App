using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace please2.Migrations
{
    /// <inheritdoc />
    public partial class livreee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "img",
                table: "Livre",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "img",
                table: "Livre",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");
        }
    }
}
