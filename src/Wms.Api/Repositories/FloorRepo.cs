using Wms.Api.DataAccess;
using Wms.Api.Extensions;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class FloorRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    public async Task<Floor> GetFloor(Guid id) {
        var floor = await _db.Floors
            .Include(f => f.Rooms)
            .SingleOrThrowAsync(f => f.Id == id);
        return floor;
    }

    public async Task Create(Floor floor) {
        _db.Floors.Add(floor);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Floor floor) {
        _db.Floors.Update(floor);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Floor floor) {
        _db.Floors.Remove(floor);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Floor>> GetFloors() {
        var floors = await _db.Floors.ToListAsync();
        return floors;
    }
}
