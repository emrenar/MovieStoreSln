using Microsoft.EntityFrameworkCore;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly MovieStoreDbContext _context;

        public MoviesViewModel Model { get; set; }

        public GetMoviesQuery(MovieStoreDbContext context)
        {
            _context = context;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _context.Movies.Include(y=>y.Genre).Include(z=>z.Director).Where(a=>a.IsActive==true).OrderBy(x=>x.Id).ToList<Movie>();

            List<MoviesViewModel> vm = new List<MoviesViewModel>();
            foreach (var movie in movieList)
            {
                vm.Add(new MoviesViewModel()
                {
                    MovieName=movie.MovieName,
                    DirectorName=movie.Director.DirectorName,
                    GenreName=movie.Genre.GenreName,
                    MoviePrice=movie.MoviePrice,
                    MoviePublishDate=movie.MoviePublishDate
                });
            }
            return vm;
        }

    }
    public class MoviesViewModel
    {
        public string MovieName { get; set; }
        public DateTime MoviePublishDate { get; set; }
        public decimal MoviePrice { get; set; }
        public string DirectorName { get; set; }
        public string GenreName { get; set; }
    }
}
