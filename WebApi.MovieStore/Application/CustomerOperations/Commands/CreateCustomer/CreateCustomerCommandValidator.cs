using FluentValidation;

namespace WebApi.MovieStore.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator:AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.Model.CustomerName).MinimumLength(2);
            RuleFor(x => x.Model.CustomerSurname).MinimumLength(2);
        }
    }
}
