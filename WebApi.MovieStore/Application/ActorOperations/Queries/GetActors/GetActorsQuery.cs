using AutoMapper;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorsViewModel Model { get; set; }

        public GetActorsQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ActorsViewModel> Handle()
        {
            var actorList = _context.Actors.Where(x => x.IsActive == true).OrderBy(y => y.Id).ToList<Actor>();
            List<ActorsViewModel> avm = _mapper.Map<List<ActorsViewModel>>(actorList);
            return avm;
        }
    }
    public class ActorsViewModel
    {
        public string ActorName { get; set; }

        public string ActorSurname { get; set; }

    }
}
