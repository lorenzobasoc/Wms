using Wms.Api.Dtos.Seats;

namespace Wms.Api.Entities;

public class Seat : DomainEntity
{
    public string Name { get; set; }

    public Table Table { get; set; }
    public Guid TableId { get; set; }

    public AppFile Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public List<Booking> Bookings { get; set; }

    public SeatDetaiDto ToSeatDetail() {
        return new SeatDetaiDto {
            Name = Name,
            Photo = Photo.Data,
            TableId = TableId,
        };
    }
}