namespace RentalSystem.Models;

public class EFRentalRepository : IRentalRepository
{
    private RentalDbContext context;

    public EFRentalRepository(RentalDbContext ctx)
    {
        context = ctx;
    }

    public IQueryable<Transport> Transports => context.Transports;
}