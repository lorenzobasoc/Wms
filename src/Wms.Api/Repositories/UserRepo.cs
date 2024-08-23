using Wms.Api.DataAccess;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class UserRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    public async Task<User> GetUser(string email) {
        var user = await _db.Users.SingleOrDefaultAsync(u => u.Email == email);
        return user;
    }

    public async Task<User> GetUser(Guid id) {
        var user = await _db.Users
            .Include(u => u.Photo)
            .SingleOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task Create(User user) {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
    }

    public async Task Update(User user) {
        _db.Users.Update(user);
        await _db.SaveChangesAsync();
    }

    public async Task<List<User>> GetUsers(IEnumerable<string> roles) {
        var users = await _db.Users
            .Where(u => !u.Disabled)
            .Where(u => roles.Contains(u.Role))
            .ToListAsync();
        return users;
    }
}
