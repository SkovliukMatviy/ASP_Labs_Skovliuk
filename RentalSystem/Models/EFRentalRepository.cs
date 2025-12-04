namespace RentalSystem.Models;

public class EFRentalRepository : IRentalRepository
{
    private RentalDbContext context;
    public EFRentalRepository(RentalDbContext ctx) { context = ctx; }

    public IQueryable<Transport> Transports => context.Transports;

    public void CreateTransport(Transport t)
    {
        context.Add(t);
        context.SaveChanges();
    }

    public void SaveTransport(Transport t)
    {
        context.SaveChanges();
    }

    public void DeleteTransport(Transport t)
    {
        context.Remove(t);
        context.SaveChanges();
    }
}