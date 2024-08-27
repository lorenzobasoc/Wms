using Wms.Api.Dtos.Rooms;

namespace Wms.Api.Entities;

public class Room : DomainEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsMeetingRoom { get; set; }
    // public ? Position { get; set; }
    
    public AppFile Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public Floor Floor { get; set; }
    public Guid FloorId { get; set; }

    public List<Table> Tables { get; set; }

    public List<Booking> Bookings { get; set; }

    public RoomDetailDto ToRoomDetail() {
        return new RoomDetailDto {
            Name = Name,
            Description = Description,
            Tables = Tables?
                .Select(t => t.ToTableDetail())
                .ToArray(),
            FloorId = FloorId,
        };
    }
}
