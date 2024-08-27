using Wms.Api.Dtos.Seats;

namespace Wms.Api.Entities;

public class Seat : DomainEntity
{
    public string Name { get; set; }

    public Table Table { get; set; }
    public Guid TableId { get; set; }

    public List<Booking> Bookings { get; set; }

    public SeatDetaiDto ToSeatDetail() {
        return new SeatDetaiDto {
            Name = Name,
            TableId = TableId,
        };
    }
}