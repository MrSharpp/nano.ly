namespace Nanoly.Entities;

public class User
{
    public int Id { get; set; }

    public required string email { get; set; }

    public required string password { get; set; }

    public string? refreshToken { get; set; } = null;

    public virtual SpaceName[] SpaceNames { get; set; }
}