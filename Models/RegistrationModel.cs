using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

/// <summary>Registration form model with full data-annotation validation.</summary>
public class RegistrationModel
{
    [Required(ErrorMessage = "Full name is required.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be 3-50 characters.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please confirm your password.")]
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please pick how you will join.")]
    public string Interest { get; set; } = "Attendee";
}
