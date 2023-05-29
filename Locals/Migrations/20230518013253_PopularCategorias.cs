using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locals.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //populando a tabela Categoria através do método Sql utilizando a instância do migrationBuilder
            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
                "VALUES('Rustico','Imóveis com ambientaçao relembrando antiguidade/prezando por preservar a identidade da epoca')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
                "VALUES('Praia','Imóveis beira mar ou que tenha proximade com praia.')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
                "VALUES('Alto padrao','Imóveis com requinte de luxo e adicionais como psicinas, áreas de lazer, espaço reservado, locais com localizaçao privilegiada.')");

            migrationBuilder.Sql("INSERT INTO Categorias(CategoriaNome, Descricao) " +
                "VALUES('Urbano','Imóveis situados em regiões urbanas, ideais para quem procura estadia por longos periodos.')");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            //Definindo o método para deletar essas tabelas caso necessário.
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
