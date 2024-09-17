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

public class UserBookingDtoValidator : Validator<UserBookingDto>
{
    public UserBookingDtoValidator() {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("No user provided for booking");
    }
}
