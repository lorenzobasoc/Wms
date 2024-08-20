namespace Wms.Api.Entities;

public class Room : DomainEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    // public ? Position { get; set; }
    
    public File Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public Floor Floor { get; set; }
    public Guid FloorId { get; set; }

    public List<Table> Tables { get; set; }

    public List<Booking> Bookings { get; set; }
}
