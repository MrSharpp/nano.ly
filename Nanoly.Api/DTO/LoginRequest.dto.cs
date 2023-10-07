namespace Nanoly.Dto;
using System.ComponentModel.DataAnnotations;

public class LoginRequestDTO
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}