using Wms.Api.Dtos.Seats;

namespace Wms.Api.Entities;

public class Seat : DomainEntity
{
    public string Name { get; set; }

    public Table Table { get; set; }
    public Guid TableId { get; set; }

    public List<SeatBooking> Bookings { get; set; }

    public SeatDetailDto ToSeatDetail() {
        return new SeatDetailDto {
            Name = Name,
            TableId = TableId,
        };
    }
}