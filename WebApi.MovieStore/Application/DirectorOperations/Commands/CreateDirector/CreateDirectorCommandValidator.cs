using FluentValidation;

namespace WebApi.MovieStore.Application.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator:AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x => x.Model.DirectorName).MinimumLength(2);
            RuleFor(x => x.Model.DirectorSurname).MinimumLength(2);
        }
    }
}
