using Microsoft.EntityFrameworkCore;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly MovieStoreDbContext _context;
        public int DeleteDirectorId { get; set; }
        public DeleteDirectorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.Include(y=>y.Movies).SingleOrDefault(x => x.Id == DeleteDirectorId);
            if (director is null)
            {
                throw new InvalidOperationException("Böyle bir yönetmen yok");
            }
            if (_context.Movies.Any(x=>x.DirectorId==DeleteDirectorId))
            {
                throw new InvalidOperationException("Yazarın bir filmi olduğu için silemezsiniz.");
            }
            director.IsActive = false;
            _context.SaveChanges();
        }
    }
}
