using Microsoft.EntityFrameworkCore;
using Nanoly.Entities;

namespace Nanoly.Services;

public class SpaceNameService
{
    private readonly PostgresDBContext _dbContext;
    public SpaceNameService(PostgresDBContext context)
    {
        _dbContext = context;
    }

    public async Task<List<SpaceName>> getAllSpaceNames(int id)
    {
        return await _dbContext.SpaceName.FromSql($"SELECT * FROM \"SpaceName\" WHERE \"UserId\" = {id}").ToListAsync();
    }

}