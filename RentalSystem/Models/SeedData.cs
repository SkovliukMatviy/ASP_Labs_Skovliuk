using Microsoft.EntityFrameworkCore;

namespace RentalSystem.Models;

public static class SeedData
{
    public static void EnsurePopulated(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<RentalDbContext>();

          
            if (context.Transports.Any())
            {
                return;
            }

          
            context.Transports.AddRange(
                new Transport
                {
                    Model = "Toyota Camry",
                    Description = "Надійний седан бізнес-класу з кондиціонером.",
                    Category = "Автомобіль",
                    PricePerDay = 1200
                },
                new Transport
                {
                    Model = "Xiaomi Scooter Pro 2",
                    Description = "Легкий та швидкий електросамокат для міста.",
                    Category = "Самокат",
                    PricePerDay = 300
                },
                new Transport
                {
                    Model = "BMW X5",
                    Description = "Преміум позашляховик для комфортних подорожей.",
                    Category = "Автомобіль",
                    PricePerDay = 3500
                },
                new Transport
                {
                    Model = "Велосипед гірський",
                    Description = "Чудовий вибір для активного відпочинку в парку.",
                    Category = "Велосипед",
                    PricePerDay = 150
                }
            );

            context.SaveChanges();
        }
    }
}