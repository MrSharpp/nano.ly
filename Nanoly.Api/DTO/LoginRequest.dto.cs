namespace Nanoly.Dto;

public class LoginRequestDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}