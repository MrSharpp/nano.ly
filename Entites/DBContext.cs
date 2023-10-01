using Microsoft.EntityFrameworkCore;
namespace Nanoly.Entities;


public class PostgresDBContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Segment> Segments { get; set; }
    public DbSet<Resource> Resources { get; set; }

    public PostgresDBContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
    }

}