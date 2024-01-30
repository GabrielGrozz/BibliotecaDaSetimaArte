using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Models;
using BibliotecaDaSetimaArte.Repository.Interfaces;

namespace BibliotecaDaSetimaArte.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {

        public MovieRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Movie> GetByYear()
        {
            return Get().OrderBy(e => e.ReleaseDate).ToList();
        }
    }
}
