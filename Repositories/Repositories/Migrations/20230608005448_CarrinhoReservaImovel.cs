using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locals.Migrations
{
    /// <inheritdoc />
    public partial class CarrinhoReservaImovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarrinhoReservaItens",
                columns: table => new
                {
                    CarrinhoReservaImovelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImovelId = table.Column<int>(type: "int", nullable: true),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSaida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarrinhoReservaId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    HoraReservado = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoReservaItens", x => x.CarrinhoReservaImovelId);
                    table.ForeignKey(
                        name: "FK_CarrinhoReservaItens_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "ImovelId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoReservaItens_ImovelId",
                table: "CarrinhoReservaItens",
                column: "ImovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoReservaItens");
        }
    }
}
