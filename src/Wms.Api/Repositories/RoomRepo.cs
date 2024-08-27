using Wms.Api.DataAccess;
using Wms.Api.Extensions;
using Wms.Api.Infrastructure;

namespace Wms.Api.Repositories;

public class RoomRepo(AppConfiguration config, Db db) : BaseRepo(config, db)
{
    public async Task<Room> GetRoomInfo(Guid id) {
        var room = await _db.Rooms.SingleOrThrowAsync(r => r.Id == id);
        return room;
    }
    
    public async Task<Room> GetRoomWithSeats(Guid id) {
        var room = await _db.Rooms
            .Include(r => r.Photo)
            .Include(r => r.Tables)
                .ThenInclude(t => t.Seats)
            .SingleOrThrowAsync(r => r.Id == id);
        return room;
    }

    public async Task Create(Room room) {
        if (room.Photo != null) {
            _db.AppFiles.Add(room.Photo);
        }
        _db.Rooms.Add(room);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Room room) {
        _db.Rooms.Update(room);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(Room room) {
        _db.Rooms.Remove(room);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Room>> GetRooms(Guid floorId) {
        var rooms = await _db.Rooms
            .Where(r => r.FloorId == floorId)
            .ToListAsync();
        return rooms;
    }
}
