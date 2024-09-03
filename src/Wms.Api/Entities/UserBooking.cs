namespace Wms.Api.Entities;

public class UserBooking : DomainEntity
{
    public Booking Booking { get; set; }
    public Guid BookingId { get; set; }

    public User User { get; set; }
    public Guid UserId { get; set; }

    public UserBooking ToEntity() {
        return new UserBooking {
            BookingId = BookingId,
            UserId = UserId,
        };
    }
}
