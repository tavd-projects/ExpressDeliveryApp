using ExpressDeliveryApp.DTOs;
using FluentValidation;

namespace ExpressDeliveryApp.Validators;

public class UpdateTicketDtoValidator : AbstractValidator<UpdateTicketDto>
{
    public UpdateTicketDtoValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.CustomerName).NotEmpty();
        RuleFor(x => x.СargoСollectionTime).Must(BeGreaterThanCurrentDateTime);
        RuleFor(x => x.WeightKg).GreaterThan(0);
        RuleFor(x => x.Id).NotEmpty();
    }
    
    private bool BeGreaterThanCurrentDateTime(DateTime dateTime)
    {
        return dateTime > DateTime.Now;
    }
}