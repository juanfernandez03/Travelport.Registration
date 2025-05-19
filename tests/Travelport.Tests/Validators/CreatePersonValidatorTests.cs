using FluentAssertions;
using Travelport.Application.DTOs;
using Travelport.Application.Validators;

namespace Travelport.Tests.Validators;

public class CreatePersonValidatorTests
{
    [Fact]
    public void Should_Validate_Correct_Passport()
    {
        var validator = new CreatePersonValidator();
        var command = new CreatePersonCommand
        {
            Name = "Laura",
            Surname = "Fernández",
            PassportNumber = "PA1234567",
            AirportCode = "MAD"
        };

        var result = validator.Validate(command);

        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("12345678")]
    [InlineData("PX123456")]  // 6 digits
    [InlineData("ZZ1234567")]
    public void Should_Fail_Invalid_Passport(string invalidPassport)
    {
        var validator = new CreatePersonValidator();
        var command = new CreatePersonCommand
        {
            Name = "Laura",
            Surname = "Fernández",
            PassportNumber = invalidPassport,
            AirportCode = "MAD"
        };

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Should_Fail_If_AirportCode_Is_Invalid()
    {
        var validator = new CreatePersonValidator();
        var command = new CreatePersonCommand
        {
            Name = "Laura",
            Surname = "Fernández",
            PassportNumber = "PA1234567",
            AirportCode = "ZZZ"
        };

        var result = validator.Validate(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "AirportCode");
    }
}
