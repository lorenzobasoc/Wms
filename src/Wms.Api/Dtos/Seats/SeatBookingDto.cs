namespace Wms.Api.Dtos.Seats;

public class SeatBookingDto
{
    public Guid SeatId { get; set; }
    public Guid BookingId { get; set; }

     public SeatBooking ToEntity() {
        return new SeatBooking {
            BookingId = BookingId,
            SeatId = SeatId,
        };
    }
}
