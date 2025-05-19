using Travelport.Application.DTOs;
using Travelport.Application.Interfaces;
using Travelport.Domain.Entities;

namespace Travelport.Application.Services;

public class PersonService
{
    private readonly IPersonRepository _repository;

    public PersonService(IPersonRepository repository)
    {
        _repository = repository;
    }

    public async Task<Person> RegisterAsync(CreatePersonCommand command)
    {
        var person = new Person(
            command.Name,
            command.Surname,
            command.Email,
            command.PassportNumber,
            command.Phone,
            command.AirportCode);

        return await _repository.AddAsync(person);
    }
}
