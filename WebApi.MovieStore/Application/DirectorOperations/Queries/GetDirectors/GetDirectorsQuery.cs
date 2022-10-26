using AutoMapper;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorsQueryModel Model { get; set; }

        public GetDirectorsQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetDirectorsQueryModel> Handle()
        {
            var director = _context.Directors.Where(x => x.IsActive == true).OrderBy(y=>y.Id).ToList<Director>();
            List<GetDirectorsQueryModel> dl = _mapper.Map<List<GetDirectorsQueryModel>>(director);
            return dl;
        }

    }
    public class GetDirectorsQueryModel
    {
        public int Id { get; set; }

        public string DirectorName { get; set; }

        public string DirectorSurname { get; set; }
    }
}
