using System.ComponentModel.DataAnnotations;

namespace RentalSystem.Models.ViewModels;

public class RegisterModel
{
    [Required(ErrorMessage = "Введіть ім'я користувача")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Введіть Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [UIHint("password")]
    public string Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Паролі не співпадають")]
    [UIHint("password")]
    public string ConfirmPassword { get; set; }
}