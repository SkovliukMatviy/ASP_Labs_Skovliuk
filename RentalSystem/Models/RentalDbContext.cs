using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RentalSystem.Models;

public class RentalDbContext : DbContext
{
    public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options) { }

    public DbSet<Transport> Transports => Set<Transport>();
}