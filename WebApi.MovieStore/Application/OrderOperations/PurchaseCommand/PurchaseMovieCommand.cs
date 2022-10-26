using Microsoft.EntityFrameworkCore;
using WebApi.MovieStore.DbOperations;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.Application.OrderOperations.PurchaseCommand
{
    public class PurchaseMovieCommand
    {
        private readonly MovieStoreDbContext _context;
        public PurchaseMovieModel Model { get; set; }

        public PurchaseMovieCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        
        public void Handle()
        {
            var order = _context.Orders.Include(x => x.Customer).Include(y => y.Movie).SingleOrDefault(z => z.MovieId==Model.MovieId);
            if (order is not null)
            {
                throw new InvalidOperationException("Bu filmi daha önce satın aldınız.");
            }
            order = new Order();
            order.CustomerId = Model.CustomerId;
            order.MovieId = Model.MovieId;
            order.MoviePrice = Model.MoviePrice;
            //order.PurchaseDate = Model.PurchasedDate;
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

    }
    public class PurchaseMovieModel
    {
       
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public decimal MoviePrice { get; set; }
        //public DateTime PurchasedDate { get; set; }
    }
}
