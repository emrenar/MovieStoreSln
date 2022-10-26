using FluentValidation;

namespace WebApi.MovieStore.Application.ActorOperations.Queries.GetActorDetails
{
    public class GetActorDetailValidator:AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailValidator()
        {
            RuleFor(x => x.ActorDetailId).GreaterThan(0);
        }
    }
}
