namespace Wms.Api.Entities;

public class Floor : DomainEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Room> Rooms { get; set; }
}
