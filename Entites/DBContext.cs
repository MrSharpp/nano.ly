using Microsoft.EntityFrameworkCore;
namespace Nanoly.Entities;


public class PostgresDBContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<SpaceName> SpaceName { get; set; }
    public DbSet<Link> Link { get; set; }

    public PostgresDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
    }

}