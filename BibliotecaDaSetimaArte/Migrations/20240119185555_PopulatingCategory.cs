using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaDaSetimaArte.Migrations
{
    public partial class PopulatingCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categories(Name, Description)" +
                "VALUES('Ação','Filmes de ação são caracterizados por cenas de luta, perseguição," +
                " tiroteio e explosões. Eles geralmente apresentam um protagonista forte e habilidoso que" +
                " enfrenta vilões cruéis e poderosos. Os filmes de ação são conhecidos por sua trama emocionante" +
                " e ritmo acelerado, que mantêm o espectador na ponta da cadeira')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM categories");
        }
    }
}
