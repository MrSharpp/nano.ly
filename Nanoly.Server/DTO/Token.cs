namespace Nanoly.Dto;

public class Token
{
    public required string AccessToken { get; set; }
    public required string RefreshToken { get; set; }
}