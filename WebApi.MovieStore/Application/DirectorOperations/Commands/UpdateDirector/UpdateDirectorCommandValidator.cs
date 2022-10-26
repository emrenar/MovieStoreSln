using FluentValidation;

namespace WebApi.MovieStore.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator:AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(x => x.Model.DirectorName).MinimumLength(2);
            RuleFor(x => x.Model.DirectorSurname).MinimumLength(2);
        }
    }
}
