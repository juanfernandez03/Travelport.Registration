using Microsoft.EntityFrameworkCore;
using Travelport.Domain.Entities;

namespace Travelport.Infrastructure.DbContext;

public class RegistrationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Person> People => Set<Person>();
}
