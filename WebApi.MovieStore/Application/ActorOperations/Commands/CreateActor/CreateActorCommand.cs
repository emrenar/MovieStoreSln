using AutoMapper;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorModel Model { get; set; }

        public CreateActorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.ActorName == Model.ActorName && x.ActorSurname == Model.ActorSurname);
            if (actor is not null)
            {
                throw new InvalidOperationException("Bu aktör zaten kayıtlı.");
            }
            actor = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

    }
    public class CreateActorModel
    {
        public string ActorName { get; set; }

        public string ActorSurname { get; set; }

        public int MovieId { get; set; }
    }
}
