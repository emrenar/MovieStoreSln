
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        private readonly MovieStoreDbContext _context;

        public UpdateMovieCommand(MovieStoreDbContext context)
        {
            _context = context;
        }

        public UpdateMovieDto Model { get; set; }

        public int UpdateMovieId { get; set; }

        public void Handle()
        {
            var movie = _context.Movies.Where(x => x.Id == UpdateMovieId).SingleOrDefault();
            if (movie is null)
            {
                throw new InvalidOperationException("Aradığınız kitap bulunamadı.");
            }
            movie.MovieName = Model.MovieName == default ? movie.MovieName : Model.MovieName;
            movie.MoviePublishDate = Model.MoviePublishDate == default ? movie.MoviePublishDate : Model.MoviePublishDate;
            movie.MoviePrice = Model.MoviePrice == default ? movie.MoviePrice : Model.MoviePrice;
            movie.DirectorId = Model.DirectorId == default ? movie.DirectorId : Model.DirectorId;
            movie.GenreId = Model.GenreId == default ? movie.GenreId : Model.GenreId;
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

    }
    public class UpdateMovieDto
    {
        public string MovieName { get; set; }
        public DateTime MoviePublishDate { get; set; }
        public decimal MoviePrice { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}
