using FluentValidation;

namespace WebApi.MovieStore.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidator:AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.DeleteActorId).GreaterThan(0);
        }
    }
}
