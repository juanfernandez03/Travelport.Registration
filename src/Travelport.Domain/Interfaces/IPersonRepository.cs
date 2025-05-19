using Travelport.Domain.Entities;

namespace Travelport.Application.Interfaces;

public interface IPersonRepository
{
    Task<Person> AddAsync(Person person);
    Task<List<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(Guid id);
    Task UpdateAsync(Person person);
    Task DeleteAsync(Guid id);
}
