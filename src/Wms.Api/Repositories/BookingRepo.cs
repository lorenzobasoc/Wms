using Wms.Api.DataAccess;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class BookingRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    public async Task<List<Booking>> ListActives(Guid userId) {
        var bookings = await _db.Bookings
            .Where(b => b.IsActive())
            .Where(b => b.UserId == userId)
            .ToListAsync();
        return bookings;
    }
    
    public async Task<List<Booking>> ListClosed(Guid userId) {
        var bookings = await _db.Bookings
            .Where(b => b.IsClosed())
            .Where(b => b.UserId == userId)
            .ToListAsync();
        return bookings;
    }

    public async Task<List<Booking>> List() {
        var bookings = await _db.Bookings.ToListAsync();
        return bookings;
    }
}
