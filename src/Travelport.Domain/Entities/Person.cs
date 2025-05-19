namespace Travelport.Domain.Entities;

public class Person
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Email { get; private set; }
    public string PassportNumber { get; private set; }
    public string Phone { get; private set; }
    public string AirportCode { get; private set; }

    private Person() { } 

    public Person(string name, string surname, string email, string passportNumber, string phone, string airportCode)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Email = email;
        PassportNumber = passportNumber;
        Phone = phone;
        AirportCode = airportCode;

    }

    public void Update(string name, string surname, string email, string passportNumber, string phone, string airportCode)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PassportNumber = passportNumber;
        Phone = phone;
        AirportCode = airportCode;
    }
}
