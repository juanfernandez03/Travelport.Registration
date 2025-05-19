namespace Travelport.Application.DTOs;

public record class CreatePersonCommand
{
    public string Name { get; init; } = string.Empty;
    public string Surname { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string PassportNumber { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string AirportCode { get; init; } = string.Empty;
}

