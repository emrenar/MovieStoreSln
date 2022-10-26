using FluentValidation;

namespace WebApi.MovieStore.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator :AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.Model.DirectorId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.MovieName).MinimumLength(1);
            RuleFor(x => x.Model.MoviePrice).GreaterThan(0);
            RuleFor(x => x.Model.MoviePublishDate).LessThan(DateTime.Now);
        }
    }
}
