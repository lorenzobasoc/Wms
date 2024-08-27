namespace Wms.Api.Dtos.Seats;

public class SeatDetaiDto
{
    public string Name { get; set; }
    public byte[] Photo { get; set; }
    public Guid TableId { get; set; }
}
