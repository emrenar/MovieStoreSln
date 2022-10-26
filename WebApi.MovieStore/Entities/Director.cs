using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.MovieStore.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string DirectorName { get; set; }

        public string DirectorSurname { get; set; }

        public List<Movie> Movies { get; set; }

        public bool IsActive { get; set; } = true;


    }
}
