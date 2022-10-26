using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.MovieStore.Application.OrderOperations.PurchaseCommand;
using WebApi.MovieStore.Application.OrderOperations.PurchasedQuery;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private object PurchasedMovieQuery;

        public OrderController(MovieStoreDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult MoviePurchasing([FromBody] PurchaseMovieModel newOrder)
        {
            PurchaseMovieCommand command = new PurchaseMovieCommand(_context);
            command.Model = newOrder;
            PurchaseCommandValidator validator = new PurchaseCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult PurchasedMovies()
        {
            PurchasedMoviesQuery query = new PurchasedMoviesQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
    }
}
