namespace Wms.Api.Entities;

public class Booking : DomainEntity
{
    public string Title { get; set; }
    public string Note { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public User User { get; set; }
    public Guid UserId { get; set; }

    public Seat Seat { get; set; }
    public Guid? SeatId { get; set; }

    public Room Room { get; set; }
    public Guid? RoomId { get; set; }

    public List<Invitation> Invitations { get; set; }
}
