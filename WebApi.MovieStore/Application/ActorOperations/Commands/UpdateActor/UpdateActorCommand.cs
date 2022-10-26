using AutoMapper;
using WebApi.MovieStore.DbOperations;

namespace WebApi.MovieStore.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly MovieStoreDbContext _context;
     

        public UpdateActorModel Model { get; set; }
        public int UpdateId { get; set; }

        public UpdateActorCommand(MovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.Where(y => y.IsActive == true).SingleOrDefault(x => x.Id == UpdateId);
            if (actor is null)
            {
                throw new InvalidOperationException("Böyle bir aktör yok");
            }
            actor.ActorName = Model.ActorName = default ? actor.ActorName : Model.ActorName;
            actor.ActorSurname = Model.ActorSurname = default ? actor.ActorSurname : Model.ActorSurname;
            actor.MovieId = Model.MovieId = default ? actor.MovieId : Model.MovieId;
            _context.Actors.Update(actor);
            _context.SaveChanges();
        }
    }
    public class UpdateActorModel
    {
        public string ActorName { get; set; }

        public string ActorSurname { get; set; }

        public int MovieId { get; set; }

    }
}
