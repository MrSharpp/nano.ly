using System.ComponentModel.DataAnnotations;

namespace Nanoly.Dto;

public class RefreshTokenRequestDTO
{
    [Required]
    public string AccessToken { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}