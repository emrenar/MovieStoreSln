using FluentValidation;

namespace WebApi.MovieStore.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator:AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Model.DirectorId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.MovieName).MinimumLength(1);
            RuleFor(x => x.Model.MoviePrice).GreaterThan(0);
            RuleFor(x => x.Model.MoviePublishDate).LessThan(DateTime.Now);
        }
    }
}
