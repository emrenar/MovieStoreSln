using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        private readonly MovieStoreDbContext _context;
        public int MovieId { get; set; }

        public DeleteMovieCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
            {
                throw new InvalidOperationException("Movie not found.");
            }
            movie.IsActive = false;
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }
    }
}
