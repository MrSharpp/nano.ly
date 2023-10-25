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

    public async Task<List<SpaceName>> findSpaceNames(string spaceName)
    {
        return await _dbContext.SpaceName.Where(x => EF.Functions.Like(spaceName, x.name)).ToListAsync();
    }

    public async Task<List<SpaceName>> getAllSpaceNames(int id)
    {
        return await _dbContext.User.Where(x => x.Id == id).SelectMany(x => x.SpaceNames).ToListAsync();
    }

    public async Task<SpaceName> addSpaceName(SpaceName spaceName)
    {
        await _dbContext.SpaceName.AddAsync(spaceName);

        await _dbContext.SaveChangesAsync();

        return spaceName;
    }

    public async Task<bool> isSpaceNameTaken(string name)
    {
        var count = await _dbContext.SpaceName.CountAsync(x => x.name == name);

        return count > 0;
    }

    public async Task updateSpaceName(SpaceName uptSpaceName)
    {
        _dbContext.SpaceName.Update(uptSpaceName);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<SpaceName> findSpaceNameById(int spaceNameId)
    {
        return await _dbContext.SpaceName.FindAsync(spaceNameId);
    }

    public async Task<Link> getSpaceName(string name, string? path = "/")
    {
        return await _dbContext.SpaceName.Where(x => x.name == name).Select(x => x.links.FirstOrDefault(x => x.name == path)).FirstOrDefaultAsync();
    }

    public async Task deleteSpaceName(SpaceName spaceName)
    {
        _dbContext.SpaceName.Remove(spaceName);
        await _dbContext.SaveChangesAsync();
    }
}