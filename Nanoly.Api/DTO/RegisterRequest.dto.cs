namespace Nanoly.Dto;

public class RegisterRequestDTO
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}