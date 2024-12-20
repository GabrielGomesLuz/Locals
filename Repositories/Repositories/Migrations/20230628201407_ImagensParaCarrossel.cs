using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locals.Migrations
{
    /// <inheritdoc />
    public partial class ImagensParaCarrossel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagensImovel",
                columns: table => new
                {
                    ImagemImovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaminhoImagem = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensImovel", x => x.ImagemImovelId);
                    table.ForeignKey(
                        name: "FK_ImagensImovel_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensImovel_ImovelId",
                table: "ImagensImovel",
                column: "ImovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensImovel");
        }
    }
}
