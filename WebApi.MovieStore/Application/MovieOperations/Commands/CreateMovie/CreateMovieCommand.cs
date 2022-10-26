using AutoMapper;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        private readonly MovieStoreDbContext _context;
        public CreateMovieModel Model { get; set; }

        public CreateMovieCommand(MovieStoreDbContext context)
        {
            _context = context;           
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieName == Model.MovieName && x.DirectorId==Model.DirectorId);
            if (movie is not null)
            {
                throw new InvalidOperationException("Movie has already exist.");
            }
            movie = new Movie();
            movie.MovieName = Model.MovieName;
            movie.MoviePublishDate = Model.MoviePublishDate;
            movie.DirectorId = Model.DirectorId;
            movie.MoviePrice = Model.MoviePrice;
            movie.GenreId = Model.GenreId;

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
    public class CreateMovieModel
    {
        public string MovieName { get; set; }
        public DateTime MoviePublishDate { get; set; }
        public decimal MoviePrice { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
    }
}
