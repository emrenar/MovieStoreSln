using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.MovieStore.Application.ActorOperations.Commands.CreateActor;
using WebApi.MovieStore.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.MovieStore.Application.DirectorOperations.Commands.DeleteDirector;
using WebApi.MovieStore.Application.DirectorOperations.Commands.UpdateDirector;
using WebApi.MovieStore.Application.DirectorOperations.Queries.GetDirectorDetails;
using WebApi.MovieStore.Application.DirectorOperations.Queries.GetDirectors;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public DirectorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateDirector([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = newDirector;
            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DeleteDirectorId = id;
            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorModel updatedDirector)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.UpdateDirectorId = id;
            command.Model = updatedDirector;
            UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDirectorDetail(int id)
        {
            GetDirectorDetailsQuery query = new GetDirectorDetailsQuery(_context, _mapper);
            query.DirectorDetailId = id;
            GetDirectorDetailsValidator validator = new GetDirectorDetailsValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }

    }
}
