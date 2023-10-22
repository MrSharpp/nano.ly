namespace Nanoly.Dto;
using System.ComponentModel.DataAnnotations;

public class RegisterRequestDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 4)]
    public string Password { get; set; }
}