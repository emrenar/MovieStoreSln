using Microsoft.EntityFrameworkCore;
using WebApi.MovieStore.Entities;

namespace WebApi.MovieStore.DbOperations
{
    public class MovieStoreDbContext:DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovieJoin>()
                .HasKey(x => new { x.ActorId, x.MovieId });
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                if (e.Entity is Order order)
                {
                    if (e.State == EntityState.Added)
                    {
                        order.PurchaseDate = DateTime.Now;
                    }
                }
            });
            return base.SaveChanges();
        }
    }
}
