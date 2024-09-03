using Wms.Api.DataAccess;
using Wms.Api.Extensions;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class BookingRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    public async Task<List<Booking>> ListActives(Guid userId) {
        var bookings = await _db.Bookings
            .Include(b => b.Seats)
            .Include(b => b.Users)
            .Where(b => b.IsActive())
            .Where(b => b.HasUser(userId))
            .ToListAsync();
        return bookings;
    }
    
    public async Task<List<Booking>> ListClosed(Guid userId) {
        var bookings = await _db.Bookings
            .Include(b => b.Seats)
            .Include(b => b.Users)
            .Where(b => b.IsClosed())
            .Where(b => b.HasUser(userId))
            .ToListAsync();
        return bookings;
    }

    public async Task<List<Booking>> List() {
        var bookings = await _db.Bookings
            .Include(b => b.Seats)
            .Include(b => b.Users)
            .ToListAsync();
        return bookings;
    }

    public async Task Create(Booking booking) {
        _db.Bookings.Add(booking);
        await _db.SaveChangesAsync();
    }

    public async Task<Booking> Find(Guid bookingId) {
        var booking = await _db.Bookings
            .Include(b => b.Seats)
            .Include(b => b.Users)
            .Include(b => b.Invitations)
            .SingleOrThrowAsync(b => b.Id == bookingId);
        return booking;
    }

    public async Task Delete(Booking booking) {
        _db.Bookings.Remove(booking);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Booking booking) {
        _db.Bookings.Update(booking);
        await _db.SaveChangesAsync();
    }
}
