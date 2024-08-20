namespace Wms.Api.Entities;

public class Table : DomainEntity
{
    public string Type { get; set; }
    // public ? Position { get; set; }

    public File Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public Room Room { get; set; }
    public Guid RoomId { get; set; }

    public List<Seat> Seats { get; set; }

    public List<Invitation> Invitations { get; set; }
}
