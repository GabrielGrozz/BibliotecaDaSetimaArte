using AutoMapper;
using BibliotecaDaSetimaArte.Context;
using BibliotecaDaSetimaArte.DTOs;
using BibliotecaDaSetimaArte.Filters;
using BibliotecaDaSetimaArte.Models;
using BibliotecaDaSetimaArte.Pagination;
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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public MoviesController(IUnityOfWork context, ILogger<MoviesController> logger, IMapper mapper)
        {
            _uof = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("year/{date:int}")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetByYear(int date)
        {
            var movies = await _uof.MovieRepository.GetByYear(date);
            var moviesDTO = _mapper.Map<List<MovieDTO>>(movies);
            return moviesDTO;            
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLogginFilter))]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> Get([FromQuery] MoviesParameters moviesParameters)
        {
            var movies = await _uof.MovieRepository.GetMovies(moviesParameters) ;
            var moviesDTO = _mapper.Map<List<MovieDTO>>(movies);

            if (moviesDTO is null)
            {
                return NotFound();
            }

            return moviesDTO;
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
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var movie = await _uof.MovieRepository.Get().FirstOrDefaultAsync(e => e.MovieId == id);
            var movieDTO = _mapper.Map<MovieDTO>(movie);

            if (movieDTO is null)
            {
                return NotFound();
            }

            return movieDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovieDTO movieData)
        {

            var movie = _mapper.Map<Movie>(movieData);

            _uof.MovieRepository.Add(movie);
            await _uof.commit();

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return new CreatedAtRouteResult("GetMovie", new { id = movieData.MovieId }, movieDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, MovieDTO movieData) 
        {

            if (id != movieData.MovieId)
            {
                return BadRequest();
            }

            var movie = _mapper.Map<Movie>(movieData);

            _uof.MovieRepository.Update(movie);
            await _uof.commit();

            return Ok(); 
        }

        [HttpDelete("{id:int}")] 
        public async Task<ActionResult<MovieDTO>> Delete(int id)
        {
            var movie = _uof.MovieRepository.Get().FirstOrDefault(e => e.MovieId == id);

            if (movie is null)
            {
                return NotFound();
            }

            _uof.MovieRepository.Delete(movie);
            await _uof.commit();

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return movieDTO;
        }
    }
}
