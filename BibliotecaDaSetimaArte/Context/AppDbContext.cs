using BibliotecaDaSetimaArte.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDaSetimaArte.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        DbSet<Movie> movies { get; set; }
        DbSet<Category> categories { get; set; }
    }
}
