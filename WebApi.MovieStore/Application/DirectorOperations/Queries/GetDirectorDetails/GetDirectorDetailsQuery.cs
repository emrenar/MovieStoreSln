using AutoMapper;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailsQuery
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public int DirectorDetailId { get; set; }
        public GetDirectorsDetailQueryModel Model { get; set; }

        public GetDirectorDetailsQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetDirectorsDetailQueryModel Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Id == DirectorDetailId);
            if (director is null)
            {
                throw new InvalidOperationException("Böyle bir yönetmen yok.");
            }
            GetDirectorsDetailQueryModel dm = _mapper.Map<GetDirectorsDetailQueryModel>(director);
            return dm;
        }
    }
    public class GetDirectorsDetailQueryModel
    {

        public int Id { get; set; }

        public string DirectorName { get; set; }

        public string DirectorSurname { get; set; }

        public bool IsActive { get; set; }
    }
}
