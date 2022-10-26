using Microsoft.EntityFrameworkCore;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly MovieStoreDbContext _context;

        public GetMovieDetailQuery(MovieStoreDbContext context)
        {
            _context = context;
        }

        public int MovieId { get; set; }

        public MovieStoreDetailViewModel Model { get; set; }

        public MovieStoreDetailViewModel Handle()
        {
            var movie = _context.Movies.Include(x => x.Genre).Include(y => y.Director).Where(a => a.IsActive == true).SingleOrDefault(z => z.Id == MovieId);
            if (movie is null)
            {
                throw new InvalidOperationException("Böyle bir film yok.");
            }
            MovieStoreDetailViewModel ms = new MovieStoreDetailViewModel();
            ms.DirectorName = movie.Director.DirectorName;
            ms.MovieName = movie.MovieName;
            ms.MoviePublishDate = movie.MoviePublishDate.Date.ToString("dd/MM/yyyy");
            ms.GenreName = movie.Genre.GenreName;

            return ms;
        }
    }
    public class MovieStoreDetailViewModel
    {
        public string MovieName { get; set; }
        public string MoviePublishDate { get; set; }
        public decimal MoviePrice { get; set; }
        public string DirectorName { get; set; }
        public string GenreName { get; set; }
    }
}
