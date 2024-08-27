using Wms.Api.DataAccess;
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
}
