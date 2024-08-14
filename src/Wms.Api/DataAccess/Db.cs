using Microsoft.EntityFrameworkCore;

namespace Wms.Api.DataAccess;

public class Db(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
    }
}
