using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BibliotecaDaSetimaArte.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context) 
        {
            _context = context;
        }
        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public T GetbyId(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().SingleOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entitty)
        {
            _context.Set<T>().Remove(entitty);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}
