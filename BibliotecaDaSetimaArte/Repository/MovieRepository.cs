using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Models;
using BibliotecaDaSetimaArte.Pagination;
using BibliotecaDaSetimaArte.Repository.Interfaces;

namespace BibliotecaDaSetimaArte.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {

        public MovieRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Movie>> GetByYear(int date)
        {
            return Get().Where(e => e.ReleaseDate == date);
        }

        public async Task<IEnumerable<Movie>> GetMovies(MoviesParameters moviesParameters)
        {
            return Get()
                .OrderBy(e => e.Name)
                .Skip((moviesParameters.PageNumber -1) * moviesParameters.PageSize)
                .Take(moviesParameters.PageSize)
                .ToList();
        }
    }
}
