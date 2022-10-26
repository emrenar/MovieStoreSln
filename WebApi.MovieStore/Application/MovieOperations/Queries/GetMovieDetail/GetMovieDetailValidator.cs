using FluentValidation;

namespace WebApi.MovieStore.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailValidator :AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
        }
    }
}
