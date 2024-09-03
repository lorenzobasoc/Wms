using Wms.Api.Dtos.Bookings;

namespace Wms.Api.Entities;

public class Booking : DomainEntity
{
    public string Title { get; set; }
    public string Note { get; set; }
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Room Room { get; set; }
    public Guid? RoomId { get; set; }

    public List<UserBooking> Users { get; set; }

    public List<SeatBooking> Seats { get; set; }
    
    public List<Invitation> Invitations { get; set; }

    public bool IsActive() {
        return EndDate.CompareTo(DateTime.Now) < 0;
    }

    public bool IsClosed() {
        return EndDate.CompareTo(DateTime.Now) >= 0;
    }

    public BookingDetailDto ToBookingDetail() {
        return new BookingDetailDto {
            Title = Title,
            Note = Note,
            StartDate = StartDate,
            EndDate = EndDate,
            RoomId = RoomId,
            Seats = Seats
                .Select(s => s.Seat.ToSeatDetail())
                .ToList(),
            Users = Users
                .Select(u => u.User.ToUserDetail())
                .ToList(),
            Invitations = Invitations
                .Select(i => i.ToinvitationDetailDto())
                .ToList(),
        };
    }

    public bool HasUser(Guid userId) {
        return Users
            .Select(u => u.UserId)
            .Contains(userId);
    }
}
