using FluentValidation;

namespace WebApi.MovieStore.Application.OrderOperations.PurchaseCommand
{
    public class PurchaseCommandValidator:AbstractValidator<PurchaseMovieCommand>
    {
        public PurchaseCommandValidator()
        {
            RuleFor(x => x.Model.CustomerId).GreaterThan(0);
            RuleFor(x => x.Model.MovieId).GreaterThan(0);
            RuleFor(x => x.Model.MoviePrice).GreaterThan(0);
        }
    }
}
