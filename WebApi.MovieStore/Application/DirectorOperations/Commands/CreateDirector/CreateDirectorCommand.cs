using AutoMapper;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateDirectorModel Model { get; set; }

        public CreateDirectorCommand(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var director = _context.Directors.Where(x => x.IsActive == true).SingleOrDefault(y=>y.DirectorName==Model.DirectorName && y.DirectorSurname==Model.DirectorSurname);
            if(director is not null)
            {
                throw new InvalidOperationException("Bu yönetmen zaten var.");
            }
            director = _mapper.Map<Director>(Model);
            _context.Directors.Add(director);
            _context.SaveChanges();
        }
    }
    public class CreateDirectorModel
    {
        public string DirectorName { get; set; }

        public string DirectorSurname { get; set; }
    }
}
