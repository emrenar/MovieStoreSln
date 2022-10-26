using FluentValidation;

namespace WebApi.MovieStore.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator:AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Model.ActorName).MinimumLength(4);
            RuleFor(x => x.Model.ActorSurname).MinimumLength(2);
            RuleFor(x => x.Model.MovieId).GreaterThan(0);

        }
    }
}
