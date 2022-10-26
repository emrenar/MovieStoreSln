using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.MovieStore.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.MovieStore.Application.CustomerOperations.Commands.DeleteCustomer;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;

        public CustomerController(MovieStoreDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerModel newCustomer )
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_context);
            command.Model = newCustomer;
            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("id")]
        public IActionResult DeleteCustomer(int id)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.CustomerID = id;
            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}
