using FluentValidation;
using Travelport.Application.DTOs;
using Travelport.Domain.Constants;

namespace Travelport.Application.Validators;

public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonValidator()
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Surname).NotEmpty();

        RuleFor(x => x.PassportNumber)
            .NotEmpty()
            .Matches("^[PL]{1}[A-Z]{1}[0-9]{7}$")
            .WithMessage("Passport must start with P or L, followed by a letter and 7 digits.");

        RuleFor(x => x.AirportCode)
            .NotEmpty()
            .Must(Airports.IsValid)
            .WithMessage("Invalid airport code.");
    }
}
