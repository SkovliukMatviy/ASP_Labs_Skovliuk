namespace RentalSystem.Models;

public interface IRentalRepository
{
    IQueryable<Transport> Transports { get; }

   
    void CreateTransport(Transport t);
    void SaveTransport(Transport t);
    void DeleteTransport(Transport t);
}