using AutoMapper;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly MovieStoreDbContext _context;

        public int UpdateDirectorId { get; set; }
        public UpdateDirectorModel Model { get; set; }

        public UpdateDirectorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.Where(x => x.Id == UpdateDirectorId).SingleOrDefault();
            if (director is null)
            {
                throw new InvalidOperationException("Böyle bir yönetmen yok");
            }
            director.DirectorName = Model.DirectorName = default ? director.DirectorName : Model.DirectorName;
            director.DirectorSurname = Model.DirectorSurname = default ? director.DirectorSurname : Model.DirectorSurname;
            _context.Directors.Update(director);
            _context.SaveChanges();
        }
    }
    public class UpdateDirectorModel
    {
        public string DirectorName { get; set; }

        public string DirectorSurname { get; set; }
    }
}
