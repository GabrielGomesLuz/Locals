using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locals.Migrations
{
    /// <inheritdoc />
    public partial class ReservaDetalhes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservaInteresse",
                columns: table => new
                {
                    ReservaInteresseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitularReserva = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EndereçoTitular = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TelefoneTitular = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    HoraReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalItensPedido = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaInteresse", x => x.ReservaInteresseId);
                });

            migrationBuilder.CreateTable(
                name: "ReservaDetalhe",
                columns: table => new
                {
                    ReservaDetalheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false),
                    ReservaInteresseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaDetalhe", x => x.ReservaDetalheId);
                    table.ForeignKey(
                        name: "FK_ReservaDetalhe_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaDetalhe_ReservaInteresse_ReservaInteresseId",
                        column: x => x.ReservaInteresseId,
                        principalTable: "ReservaInteresse",
                        principalColumn: "ReservaInteresseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaDetalhe_ImovelId",
                table: "ReservaDetalhe",
                column: "ImovelId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaDetalhe_ReservaInteresseId",
                table: "ReservaDetalhe",
                column: "ReservaInteresseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaDetalhe");

            migrationBuilder.DropTable(
                name: "ReservaInteresse");
        }
    }
}
