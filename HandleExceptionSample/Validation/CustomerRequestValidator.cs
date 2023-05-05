using HandleExceptionSample.Contracts.Requests;
using FluentValidation;



namespace HandleExceptionSample.Validation;

public class CustomerRequestValidator : AbstractValidator<CustomerRequest>
{
    public CustomerRequestValidator()
    {
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
    }
}
