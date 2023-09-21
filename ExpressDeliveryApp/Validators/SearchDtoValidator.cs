using ExpressDeliveryApp.DTOs;
using FluentValidation;

namespace ExpressDeliveryApp.Validators;

public class SearchDtoValidator : AbstractValidator<SearchDto>
{
    public SearchDtoValidator()
    {
        RuleFor(x => x.Query).MinimumLength(4).MaximumLength(100);
    }
}