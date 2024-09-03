namespace Wms.Api.Entities;

public class SeatBooking : DomainEntity
{
    public Seat Seat { get; set; }
    public Guid SeatId { get; set; }

    public Booking Booking { get; set; }
    public Guid BookingId { get; set; }
}
