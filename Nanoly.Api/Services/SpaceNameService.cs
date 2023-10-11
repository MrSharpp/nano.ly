using Nanoly.Entities;

namespace Nanoly.Services;

public class SpaceNameService
{
    private readonly PostgresDBContext _dbContext;
    public SpaceNameService(PostgresDBContext context)
    {
        _dbContext = context;
    }

    public async Task<SpaceName> getAllSegments()
    {
        return await _dbContext.SpaceName.FindAsync();
    }

}