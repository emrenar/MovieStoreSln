using FluentValidation;

namespace WebApi.MovieStore.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator:AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.Model.ActorName).MinimumLength(4);
            RuleFor(x => x.Model.ActorSurname).MinimumLength(2);
            RuleFor(x => x.Model.MovieId).GreaterThan(0);
        }
    }
}
