using Wms.Api.Dtos.Tables;

namespace Wms.Api.Entities;

public class Table : DomainEntity
{
    public string Type { get; set; }
    // public ? Position { get; set; }

    public AppFile Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public Room Room { get; set; }
    public Guid RoomId { get; set; }

    public List<Seat> Seats { get; set; }

    public List<Invitation> Invitations { get; set; }

    public TableDetailDto ToTableDetail() {
        return new TableDetailDto {
            Seats = Seats?
                .Select(s => s.ToSeatDetail())
                .ToArray(),
            RoomId = RoomId,
        };
    }
}
