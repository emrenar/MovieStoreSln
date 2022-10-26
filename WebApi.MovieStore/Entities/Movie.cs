using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string MovieName { get; set; }

        public DateTime MoviePublishDate { get; set; }

        public decimal MoviePrice { get; set; }

        public bool IsActive { get; set; } = true;

        public virtual  ICollection<Actor> Actors { get; set; }

        public Director Director { get; set; }
        public int DirectorId { get; set; }
       
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        

    }
}
