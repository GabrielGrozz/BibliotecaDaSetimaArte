using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDaSetimaArte.Controllers
{
    [ApiController]
    [Route("[controller]/{action}")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            var movie = _context.GetType

        }
    }
}
