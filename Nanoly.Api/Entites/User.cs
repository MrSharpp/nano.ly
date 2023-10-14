namespace Nanoly.Entities;

public class User
{
    public int Id { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public string? RefreshToken { get; set; } = null;

    public virtual SpaceName[] SpaceNames { get; set; }
}