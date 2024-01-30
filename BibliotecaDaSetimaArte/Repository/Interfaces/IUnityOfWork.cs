using BibliotecaDaSetimaArte.Context;

namespace BibliotecaDaSetimaArte.Repository.Interfaces
{
    public interface IUnityOfWork
    {
        IMovieRepository MovieRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        void commit();
    }
}
