using FluentValidation;

namespace WebApi.MovieStore.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidator:AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(x => x.DeleteDirectorId).GreaterThan(0);
        }
    }
}
