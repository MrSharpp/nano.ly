using Nanoly.Entities;

namespace Nanoly.Services;

public class SegmentService
{
    private readonly PostgresDBContext _dbContext;
    public SegmentService(PostgresDBContext context)
    {
        _dbContext = context;
    }

    public async Task<SpaceName> getAllSegments()
    {
        return await _dbContext.SpaceName.FindAsync();
    }
}