using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EncurtadorDeLinks.Migrations
{
    /// <inheritdoc />
    public partial class CriarColunaShortCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LinkEncurtado",
                table: "Links",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ShortCode",
                table: "Links",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortCode",
                table: "Links");

            migrationBuilder.AlterColumn<string>(
                name: "LinkEncurtado",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
