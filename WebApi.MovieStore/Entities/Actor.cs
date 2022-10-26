using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.MovieStore.Entities
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        public string ActorName { get; set; }

        public string ActorSurname { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public int MovieId { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
