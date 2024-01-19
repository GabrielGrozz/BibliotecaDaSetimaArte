using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaDaSetimaArte.Migrations
{
    public partial class PopulatingMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO movies(Name,Synopsis,ReleaseDate,ImageURL,CategoryId)" +
                "VALUES('John Wick 4','O filme segue o famoso assassino de aluguel John Wick enquanto ele luta contra" +
                " a influente organização High Table em diversas cidades, incluindo Nova York, Paris, Tóquio e Berlim1'" +
                ",2023,'https://th.bing.com/th/id/OIP.WjcMzzjyLiIUphpnryKVegHaEK?w=279&h=180&c=7&r=0&o=5&pid=1.7',1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM movies");
        }
    }
}
