using BibliotecaDaSetimaArte.Models;

namespace BibliotecaDaSetimaArte.Repository.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetByYear();
    }
}
