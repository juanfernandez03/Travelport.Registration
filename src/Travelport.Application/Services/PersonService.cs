using Microsoft.Extensions.Logging;
using Travelport.Application.DTOs;
using Travelport.Application.Interfaces;
using Travelport.Domain.Entities;

namespace Travelport.Application.Services;

public class PersonService
{
    private readonly IPersonRepository _repository;
    private readonly ILogger<PersonService> _logger;


    public PersonService(IPersonRepository repository, ILogger<PersonService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Person> RegisterAsync(CreatePersonCommand command,CancellationToken cancellationToken = default)
    {
        try
        {

       
        var person = new Person(
            command.Name,
            command.Surname,
            command.Email,
            command.PassportNumber,
            command.Phone,
            command.AirportCode);

        return await _repository.AddAsync(person,cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error registering person with passport: {PassportNumber}", command.PassportNumber);
            throw;
        }
    }

    public async Task<Person?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

}
