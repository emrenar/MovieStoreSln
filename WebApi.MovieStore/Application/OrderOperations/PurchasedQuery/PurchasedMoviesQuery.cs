using Microsoft.EntityFrameworkCore;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.OrderOperations.PurchasedQuery
{
    public class PurchasedMoviesQuery
    {
        private readonly MovieStoreDbContext _context;
        public PurchasedQueriesModel Model { get; set; }

        public PurchasedMoviesQuery(MovieStoreDbContext context)
        {
            _context = context;
        }
        public List<PurchasedQueriesModel> Handle()
        {
            var order = _context.Orders.Include(x => x.Customer).Include(y => y.Movie).ToList<Order>();
            List<PurchasedQueriesModel> pm = new List<PurchasedQueriesModel>();

            foreach (var item in order)
            {
                pm.Add(new PurchasedQueriesModel()
                {
                    MovieName=item.Movie.MovieName,
                    CustomerName=item.Customer.CustomerName,
                    MoviePrice=item.MoviePrice,
                    PurchasedDate=item.PurchaseDate.Date.ToString("dd/mm/yyyy")
                });
            }
            return pm;
        }

    }
    public class PurchasedQueriesModel
    {

        public string CustomerName { get; set; }

        public string MovieName { get; set; }

        public decimal MoviePrice { get; set; }

        public string PurchasedDate { get; set; }
    }
}
