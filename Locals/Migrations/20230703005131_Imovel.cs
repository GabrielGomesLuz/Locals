using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locals.Migrations
{
    /// <inheritdoc />
    public partial class Imovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Imagem1",
                table: "Imoveis",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem2",
                table: "Imoveis",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl3",
                table: "Imoveis",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl4",
                table: "Imoveis",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl5",
                table: "Imoveis",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Imagem1",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "Imagem2",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "ImagemUrl3",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "ImagemUrl4",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "ImagemUrl5",
                table: "Imoveis");
        }
    }
}
