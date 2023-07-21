using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locals.Migrations
{
    /// <inheritdoc />
    public partial class PopularImagensCarrossel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.Sql("INSERT INTO ImagensImovel(CaminhoImagem, ImovelId) " +
                "VALUES" +
                "('/Images/Rustico/casa1(cards)1',1)");

           



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ImagensImovel");
        }
    }
}
