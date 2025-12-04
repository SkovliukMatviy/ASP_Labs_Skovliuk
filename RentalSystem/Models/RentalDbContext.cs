using Microsoft.EntityFrameworkCore;

namespace RentalSystem.Models;

public class RentalDbContext : DbContext
{
    public RentalDbContext(DbContextOptions<RentalDbContext> options) : base(options) { }

    public DbSet<Transport> Transports => Set<Transport>();
    public DbSet<RentOrder> RentOrders => Set<RentOrder>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Transport>()
            .HasMany(t => t.RentOrders)
            .WithOne(r => r.Transport)
            .HasForeignKey(r => r.TransportID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}