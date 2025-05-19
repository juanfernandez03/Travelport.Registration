using Microsoft.EntityFrameworkCore;
using Travelport.Application.Interfaces;
using Travelport.Domain.Entities;
using Travelport.Infrastructure.DbContext;

namespace Travelport.Infrastructure.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly RegistrationDbContext _context;

    public PersonRepository(RegistrationDbContext context)
    {
        _context = context;
    }

    public async Task<Person> AddAsync(Person person, CancellationToken cancellationToken)
    {
        _context.People.Add(person);
        await _context.SaveChangesAsync(cancellationToken);
        return person;
    }

    public async Task<IReadOnlyList<Person>> GetAllAsync()
    {
        return await _context.People.ToListAsync();
    }

    public async Task<Person?> GetByIdAsync(Guid id)
    {
        return await _context.People.FindAsync(id);
    }

    public async Task UpdateAsync(Person person)
    {
        _context.People.Update(person);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var person = await _context.People.FindAsync(id);
        if (person != null)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
