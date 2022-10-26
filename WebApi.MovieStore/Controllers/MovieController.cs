using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.MovieStore.Application.MovieOperations.Commands.CreateMovie;
using WebApi.MovieStore.Application.MovieOperations.Commands.DeleteMovie;
using WebApi.MovieStore.Application.MovieOperations.Commands.UpdateMovie;
using WebApi.MovieStore.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.MovieStore.Application.MovieOperations.Queries.GetMovies;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        //private readonly IMapper _mapper;

        public MovieController(MovieStoreDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_context);
            command.Model = newMovie;
            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.MovieId = id;
            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto updateMovie)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.UpdateMovieId = id;
            command.Model = updateMovie;
            UpdateMovieCommandValidator validator = new UpdateMovieCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetMoviesList()
        {
            GetMoviesQuery query = new GetMoviesQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieDetail(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context);
            query.MovieId = id;
            GetMovieDetailValidator validator = new GetMovieDetailValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }
    }
}
