using AutoMapper;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        private readonly MovieStoreDbContext _context;
      
        public int DeleteActorId { get; set; }
        public DeleteActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == DeleteActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Böyle bir actor yok.");
            }
            actor.IsActive = false;
            _context.SaveChanges();
        }

    }
}
