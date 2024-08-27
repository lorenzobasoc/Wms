using Wms.Api.DataAccess;
using Wms.Api.Extensions;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class SeatRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    public async Task Create(Seat seat) {
        _db.Seats.Add(seat);
        await _db.SaveChangesAsync();
    }

    public async Task Create(List<Seat> seats) {
        _db.Seats.AddRange(seats);
        await _db.SaveChangesAsync();
    }

    public async Task<Seat> Find(Guid id) {
        var seat = await _db.Seats.SingleOrThrowAsync(s => s.Id == id);
        return seat;
    }

    public async Task Delete(Seat seat) {
        _db.Seats.Remove(seat);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Seat seat) {
        _db.Seats.Update(seat);
        await _db.SaveChangesAsync();
    }
}
