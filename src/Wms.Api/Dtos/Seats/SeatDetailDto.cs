namespace Wms.Api.Dtos.Seats;

public class SeatDetailDto
{
    public string Name { get; set; }
    public Guid TableId { get; set; }

    public Seat ToEntity(Guid tableId) {
        return new Seat {
            TableId = tableId,
            Name = Name,
        };
    }
}
