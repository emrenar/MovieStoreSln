using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.MovieStore.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public List<Order> Orders { get; set; }

        public List<Genre> Genres { get; set; }

        public bool IsActive { get; set; } = true;


    }
}
