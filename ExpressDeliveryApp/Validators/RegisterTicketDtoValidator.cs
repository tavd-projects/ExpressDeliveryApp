using ExpressDeliveryApp.DTOs;
using FluentValidation;

namespace ExpressDeliveryApp.Validators;

public class RegisterTicketDtoValidator : AbstractValidator<RegisterTicketDto>
{
    public RegisterTicketDtoValidator()
    {
        RuleFor(x => x.CustomerName).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.СargoСollectionTime).Must(BeGreaterThanCurrentDateTime)
            .WithMessage("The date must be greater than the current one");
        RuleFor(x => x.WeightKg).GreaterThan(0);
    }

    private bool BeGreaterThanCurrentDateTime(DateTime dateTime)
    {
        return dateTime > DateTime.Now;
    }
}