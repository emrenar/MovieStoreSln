using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.MovieStore.Application.ActorOperations.Commands.CreateActor;
using WebApi.MovieStore.Application.ActorOperations.Commands.DeleteActor;
using WebApi.MovieStore.Application.ActorOperations.Commands.UpdateActor;
using WebApi.MovieStore.Application.ActorOperations.Queries.GetActorDetails;
using WebApi.MovieStore.Application.ActorOperations.Queries.GetActors;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        [HttpPost]
        public IActionResult CreateActor([FromBody]CreateActorModel newActor)
        {
            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = newActor;
            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.DeleteActorId = id;
            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel updatedActor)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);
            command.UpdateId = id;
            command.Model = updatedActor;
            UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetActorList()
        {
            GetActorsQuery query = new GetActorsQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetActorDetail(int id)
        {
            GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
            query.ActorDetailId = id;
            GetActorDetailValidator validator = new GetActorDetailValidator();
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);
        }
    }
}
