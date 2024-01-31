using BibliotecaDaSetimaArte.Models;
using BibliotecaDaSetimaArte.Pagination;

namespace BibliotecaDaSetimaArte.Repository.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMovies(MoviesParameters moviesParameters);
        Task<IEnumerable<Movie>> GetByYear(int value);
    }
}
