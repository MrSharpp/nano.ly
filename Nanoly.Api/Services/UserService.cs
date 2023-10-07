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

    public async Task<User> GetUserByEmail(string email)
    {
        return await _dbContext.User.Where(x => x.email == email).FirstOrDefaultAsync();
    }

    public async Task CreateUser(User newUser)
    {
        await _dbContext.User.AddAsync(newUser);
    }
}