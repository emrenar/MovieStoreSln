using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.MovieStore.Entities
{
    public class ActorMovieJoin
    {
  
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public virtual Actor Actor { get; set; }

        public virtual Movie Movie { get; set; }

    }
}
