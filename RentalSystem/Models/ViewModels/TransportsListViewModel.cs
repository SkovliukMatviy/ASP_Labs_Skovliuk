namespace RentalSystem.Models.ViewModels;

public class TransportsListViewModel
{
    public IEnumerable<Transport> Transports { get; set; } = Enumerable.Empty<Transport>();
    public PagingInfo PagingInfo { get; set; } = new();

  
    public string? CurrentCategory { get; set; }
}