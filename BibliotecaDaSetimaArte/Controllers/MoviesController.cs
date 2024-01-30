using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.Filters;
using BibliotecaDaSetimaArte.Models;
using BibliotecaDaSetimaArte.Repository.Interfaces;
using BibliotecaDaSetimaArte.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaDaSetimaArte.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IUnityOfWork _uof;
        private readonly ILogger _logger;
        public MoviesController(IUnityOfWork context, ILogger<MoviesController> logger)
        {
            _uof = context;
            _logger = logger;
        }

        [HttpGet("year/{date:int}")]
        public ActionResult<IEnumerable<Movie>> GetByYear(int date)
        {
            var movies = _uof.MovieRepository.GetByYear(date).ToList();
            return movies;            
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLogginFilter))]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies = _uof.MovieRepository.Get().ToList();

            if (movies is null)
            {
                return NotFound();
            }

            return movies;
        }

        //rota de teste de restrição 
        //[HttpGet("especifico/{id:int:min(5)}")]
        //public Movie Get2(int id)
        //{
        //    var movie = _uof.MovieRepository.Get().FirstOrDefault(e => e.MovieId == 2);
        //    return movie;
        //}

        //[HttpGet("greeting/{name}")]
        //public ActionResult<string> Get3([FromServices] IMyService myService, string name)
        //{
        //    _logger.LogInformation("################################### -- [GET GREETING] -- #################################");
        //    return myService.Greeting(name);

        //}

        [HttpGet("{id:int}", Name = "GetMovie")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _uof.MovieRepository.Get().FirstOrDefault(e => e.MovieId == id);

            if (movie is null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public ActionResult Post(Movie movieData)
        {
            _uof.MovieRepository.Add(movieData);
            _uof.commit();

            return new CreatedAtRouteResult("GetMovie", new { id = movieData.MovieId }, movieData);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Movie movieData) 
        {
            if (id != movieData.MovieId)
            {
                return BadRequest();
            }

            _uof.MovieRepository.Update(movieData);
            _uof.commit();

            return Ok(); 
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var movie = _uof.MovieRepository.Get().FirstOrDefault(e => e.MovieId == id);

            if (movie is null)
            {
                return NotFound();
            }

            _uof.MovieRepository.Delete(movie);
            _uof.commit();

            return Ok();
        }
    }
}
