using ExpressDeliveryApp.DTOs;
using FluentValidation;

namespace ExpressDeliveryApp.Validators;

public class GuidDtoValidator : AbstractValidator<GuidDto>
{
    public GuidDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}