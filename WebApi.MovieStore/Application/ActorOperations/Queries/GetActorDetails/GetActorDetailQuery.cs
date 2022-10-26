using AutoMapper;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.ActorOperations.Queries.GetActorDetails
{
    public class GetActorDetailQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public ActorDetailViewModel Model { get; set; }
        public int ActorDetailId { get; set; }
        public GetActorDetailQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ActorDetailViewModel Handle()
        {
            var actorDetail = _context.Actors.Where(x => x.IsActive == true).SingleOrDefault(y => y.Id == ActorDetailId);
            if (actorDetail is null )
            {
                throw new InvalidOperationException("Böyle bir actor yok.");
            }
            ActorDetailViewModel advm = _mapper.Map<ActorDetailViewModel>(actorDetail);         
            return advm;
        }
    }
    public class ActorDetailViewModel
    {
        public string ActorName { get; set; }

        public string ActorSurname { get; set; }
    }
}
