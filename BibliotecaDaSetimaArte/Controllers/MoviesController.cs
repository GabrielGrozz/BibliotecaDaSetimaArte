using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDaSetimaArte.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies = _context.Movies.ToList();

            if (movies is null)
            {
                return NotFound();
            }

            return movies;
        }

        [HttpGet("{id:int}", Name = "GetMovie")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _context.Movies.FirstOrDefault(e => e.MovieId == id);

            if (movie is null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public ActionResult Post(Movie movieData)
        {
            _context.Movies.Add(movieData);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetMovie", new { id = movieData.MovieId }, movieData);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Movie movieData) 
        {
            if (id != movieData.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movieData).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(); 
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(e => e.MovieId == id);

            if (movie is null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok();

        }
    }
}
