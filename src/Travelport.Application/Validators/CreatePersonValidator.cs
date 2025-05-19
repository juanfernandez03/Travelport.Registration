using FluentValidation;
using Travelport.Application.DTOs;

namespace Travelport.Application.Validators;

public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonValidator()
    {
        // TODO: Define the rules for the properties
    }
}
