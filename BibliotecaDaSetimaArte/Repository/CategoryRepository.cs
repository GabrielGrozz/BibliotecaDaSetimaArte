using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Models;
using BibliotecaDaSetimaArte.Repository.Interfaces;

namespace BibliotecaDaSetimaArte.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
