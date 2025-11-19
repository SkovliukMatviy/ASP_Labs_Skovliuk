namespace RentalSystem.Models;

public class RentRequest
{
    public long TransportID { get; set; } 
    public string ClientName { get; set; } = string.Empty; 
    public int Days { get; set; } = 1; 
}