using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.MovieStore.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string GenreName { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

    }
}
