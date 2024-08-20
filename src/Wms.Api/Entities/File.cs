namespace Wms.Api.Entities;

public class File : DomainEntity
{
    public string Type { get; set; }
    public string Title { get; set; }
    public byte[] Data { get; set; }

    public User User { get; set; }
    public Room Room { get; set; }
    public Table Table { get; set; }
    public Seat Seat { get; set; }
}
