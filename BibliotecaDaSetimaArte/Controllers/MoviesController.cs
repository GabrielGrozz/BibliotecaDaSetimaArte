using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Filters;
using BibliotecaDaSetimaArte.Models;
using BibliotecaDaSetimaArte.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDaSetimaArte.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;
        public MoviesController(AppDbContext context, ILogger<MoviesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLogginFilter))]
        public async Task<ActionResult<IEnumerable<Movie>>> Get()
        {
            var movies = await _context.Movies.ToListAsync();

            if (movies is null)
            {
                return NotFound();
            }

            return movies;
        }

        //rota de teste de restrição 
        [HttpGet("especifico/{id:int:min(5)}")]
        public async Task<Movie> Get2(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(e => e.MovieId == 2);
            return movie;
        }

        [HttpGet("greeting/{name}")]
        public ActionResult<string> Get3([FromServices] IMyService myService, string name)
        {
            _logger.LogInformation("################################### -- [GET GREETING] -- #################################");
            return myService.Greeting(name);

        }

        [HttpGet("{id:int}", Name = "GetMovie")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(e => e.MovieId == id);

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
