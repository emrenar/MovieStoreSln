using FluentValidation;

namespace WebApi.MovieStore.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator:AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}
