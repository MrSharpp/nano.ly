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
        return await _dbContext.User.Where(x => x.Id == id).SelectMany(x => x.spaceNames).ToListAsync();
    }

    public async Task<SpaceName> addSpaceName(string name, string content)
    {
        var spaceName = new SpaceName()
        {
            name = name,
            content = content
        };

        await _dbContext.SpaceName.AddAsync(spaceName);

        await _dbContext.SaveChangesAsync();

        return spaceName;
    }
}