using FluentValidation;

namespace WebApi.MovieStore.Application.DirectorOperations.Queries.GetDirectorDetails
{
    public class GetDirectorDetailsValidator:AbstractValidator<GetDirectorDetailsQuery>
    {
        public GetDirectorDetailsValidator()
        {
            RuleFor(x => x.DirectorDetailId).GreaterThan(0);
        }
    }
}
