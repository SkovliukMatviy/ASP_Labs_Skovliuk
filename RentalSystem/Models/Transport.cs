using System.ComponentModel.DataAnnotations.Schema;

namespace RentalSystem.Models
{
    public class Transport
    {
        public long? TransportID { get; set; }

        public string Model { get; set; } = String.Empty;

        public string Description { get; set; } = String.Empty; 

        [Column(TypeName = "decimal(8, 2)")]
        public decimal PricePerDay { get; set; } 

        public string Category { get; set; } = String.Empty;
    }
}