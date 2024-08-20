namespace Wms.Api.Entities;

public class Seat : DomainEntity
{
    public Table Table { get; set; }
    public Guid TableId { get; set; }

    public File Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public List<Booking> Bookings { get; set; }
}
