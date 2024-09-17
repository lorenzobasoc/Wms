namespace Wms.Api.Dtos.Bookings;

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

public class SeatBookingDtoValidator : Validator<SeatBookingDto>
{
    public SeatBookingDtoValidator() {
        RuleFor(x => x.SeatId)
            .NotEmpty()
            .WithMessage("No seat provided for booking");
    }
}
