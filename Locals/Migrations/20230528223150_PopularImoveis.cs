using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locals.Migrations
{
    /// <inheritdoc />
    public partial class PopularImoveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Imoveis(CategoriaID,DescricaoCurta,DescricaoDetalhada,Disponivel,IsImovelDestaque,ImagemThumbnailUrl,ImagemUrl,Preco,NomeImovel) " +
                "VALUES(1, 'Imóvel rústico estilo chalé perfeito para descansar da rotina corrida das grandes cidades...', 'Imóvel contendo 2 quartos grandes com suítes, sala de jantar, sala de estar, cozinha, sendo 2 pisos, onde no 2 piso estão os quartos.', 1,1,'/Images/Rustico/cloud-1731_1280','/Images/Rustico/casa1(cards)',350.00,'Chalé 2 Quartos em Curitiba')");



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Imoveis");
        }
    }
}
