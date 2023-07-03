using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locals.Migrations
{
    /// <inheritdoc />
    public partial class teste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("INSERT INTO Imoveis(CategoriaID,DescricaoCurta,DescricaoDetalhada,Disponivel,IsImovelDestaque,ImagemThumbnailUrl,ImagemUrl,Preco,NomeImovel,Imagem1,Imagem2,ImagemUrl3,ImagemUrl4,ImagemUrl5) " +
                "VALUES(3, 'Imóvel alto padrão com acabamento fino, móveis especiais e exclusivos, localização privilegiada...', 'Imóvel contendo 3 quartos grandes com suítes, sala de jantar, sala de estar, cozinha, sendo 2 pisos, onde no 2 piso estão os quartos.', 1,1,'/Images/AltoPadrao/thumb.jpg','/Images/AltoPadrao/living-room.jpg',750.00,'Casa 3 Quartos em Curitiba','/Images/AltoPadrao/kitchen-.jpg','/Images/AltoPadrao/bathroom-1336165_640.jpg','/Images/AltoPadrao/apartment-1822409_640.jpg','/Images/AltoPadrao/luxury-villas-1737167_640.jpg','/Images/AltoPadrao/travel-1737168_640.jpg')");

            migrationBuilder.Sql("INSERT INTO Imoveis(CategoriaID,DescricaoCurta,DescricaoDetalhada,Disponivel,IsImovelDestaque,ImagemThumbnailUrl,ImagemUrl,Preco,NomeImovel,Imagem1,Imagem2,ImagemUrl3,ImagemUrl4,ImagemUrl5) " +
                "VALUES(1, 'Imóvel Rústico com aconchegos para fugir do urbano...', 'Imóvel contendo 2 quartos grandes com suítes, sala de jantar, sala de estar, cozinha, sendo 2 pisos, onde no 2 piso estão os quartos.', 1,1,'/Images/Rustico/Casa1/cloud-1731_1280.jpg','/Images/Rustico/Casa1/casa5(cards)3.jpg',350.00,'Casa 2 Quartos em Curitiba','/Images/Rustico/Casa1/casa5(cards)1.jpg','/Images/Rustico/Casa1/casa5(cards).jpg','/Images/Rustico/Casa1/casa1(cards)2.jpg','/Images/Rustico/Casa1/casa1(cards)1.jpg','/Images/Rustico/Casa1/casa1(cards).jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete FROM Imoveis");
        }
    }
}
