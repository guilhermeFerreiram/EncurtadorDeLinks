using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncurtadorDeLinks.Migrations
{
    /// <inheritdoc />
    public partial class CriarColunaCliques : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cliques",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliques",
                table: "Links");
        }
    }
}
