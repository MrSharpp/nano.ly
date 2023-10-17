using Microsoft.EntityFrameworkCore;
using Nanoly.Entities;

namespace Nanoly.Services;

public class UserService
{
    private readonly PostgresDBContext _dbContext;

    public UserService(PostgresDBContext context)
    {
        _dbContext = context;
    }

    public async Task<User> GetUserByEmail(string Email)
    {
        return await _dbContext.User.Where(x => x.email == Email).FirstOrDefaultAsync();
    }

    public async Task CreateUser(User newUser)
    {
        await _dbContext.User.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUser(User updatedUser)
    {
        _dbContext.User.Update(updatedUser);
        await _dbContext.SaveChangesAsync();
    }
}