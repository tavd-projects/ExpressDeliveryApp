using ExpressDeliveryApp.DTOs;
using FluentValidation;

namespace ExpressDeliveryApp.Validators;

public class CancelTicketDtoValidator : AbstractValidator<CancelTicketDto>
{
    public CancelTicketDtoValidator()
    {
        RuleFor(x => x.Guid).NotEmpty();
        RuleFor(x => x.Reason).NotEmpty().MinimumLength(5);
    }
}