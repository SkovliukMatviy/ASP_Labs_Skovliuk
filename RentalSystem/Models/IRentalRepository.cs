namespace RentalSystem.Models;

public interface IRentalRepository
{
    IQueryable<Transport> Transports { get; }
}