namespace Travelport.Application.DTOs;

public class CreatePersonCommand
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PassportNumber { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string AirportCode { get; set; } = string.Empty;
}
