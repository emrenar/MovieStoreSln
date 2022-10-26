using FluentValidation;

namespace WebApi.MovieStore.Application.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator:AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerID).GreaterThan(0);
        }
    }
}
