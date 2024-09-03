namespace Wms.Api.Dtos.Users;

public class UserBookingDto
{
    public Guid UserId { get; set; }
    public Guid BookingId { get; set; }

    public UserBooking ToEntity() {
        return new UserBooking {
            BookingId = BookingId,
            UserId = UserId,
        };
    }
}
