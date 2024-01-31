using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Repository.Interfaces;

namespace BibliotecaDaSetimaArte.Repository
{
    public class UnityOfWork : IUnityOfWork
    {

        private CategoryRepository _categoryRepository;
        private MovieRepository _movieRepository;
        private readonly AppDbContext _context;
        public UnityOfWork(AppDbContext context)
        {
                _context = context;
        }

        public IMovieRepository MovieRepository
        {
            get
            {
                return _movieRepository = _movieRepository ?? new MovieRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
            }
        }

        public async Task commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
