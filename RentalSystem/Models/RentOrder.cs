using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Models;

public class RentOrder
{
    [Key]
    public int RentOrderID { get; set; }

    [Required(ErrorMessage = "Введіть ім'я")]
    public string ClientName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть телефон")]
    [Phone]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Введіть Email")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public long TransportID { get; set; }
    public Transport? Transport { get; set; }
}