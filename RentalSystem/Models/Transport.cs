using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalSystem.Models;

public class Transport
{
    [Key]
    public long TransportID { get; set; }

    [Required(ErrorMessage = "Будь ласка, введіть модель авто")]
    [StringLength(100, ErrorMessage = "Назва занадто довга")]
    public string Model { get; set; } = string.Empty;

    [Required(ErrorMessage = "Додайте опис")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Вкажіть ціну")]
    [Range(1, 100000, ErrorMessage = "Ціна має бути більше 0")]
    [Column(TypeName = "decimal(8, 2)")]
    public decimal PricePerDay { get; set; }

    [Required(ErrorMessage = "Оберіть категорію")]
    public string Category { get; set; } = string.Empty;

    // Зв'язок: Один транспорт може мати багато замовлень
    public List<RentOrder> RentOrders { get; set; } = new();
}