using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.MovieStore.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Customer Customer { get; set; } 
        public int CustomerId { get; set; }


        public Movie Movie { get; set; }
        public int? MovieId { get; set; }


        public decimal MoviePrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        

    }
}
