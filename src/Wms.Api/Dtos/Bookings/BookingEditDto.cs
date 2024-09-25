using Wms.Api.Constants.Bookings;
using Wms.Api.Dtos.Users;

namespace Wms.Api.Dtos.Bookings;

public class BookingEditDto
{
    public string Title { get; set; }
    public string Note { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid? RoomId { get; set; }
    public List<UserBookingDto> Users { get; set; }
    public List<SeatBookingDto> Seats { get; set; }

    public Booking ToEntity() {
        return new Booking {
            Title = Title,
            Note = Note,
            StartDate = StartDate,
            EndDate = EndDate,
            RoomId = RoomId,
            Seats = Seats
                .Select(s => s.ToEntity())
                .ToList(),
            Users = Users
                .Select(u => u.ToEntity())
                .ToList(),
            Type = RoomId != null ? BookingTypes.ROOM : BookingTypes.SEAT,
        };
    }
}

public class BookingEditDtoValidator : Validator<BookingEditDto>
{
    public BookingEditDtoValidator() {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title empty");
        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Start date is in the past");
        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("End date is less than start date");
    }
}
