using Wms.Api.Dtos.Invitations;
using Wms.Api.Dtos.Seats;
using Wms.Api.Dtos.Users;

namespace Wms.Api.Dtos.Bookings;

public class BookingDetailDto
{
    public string Title { get; set; }
    public string Note { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid? RoomId { get; set; }

    public List<UserDetailDto> Users { get; set; }
    public List<SeatDetailDto> Seats { get; set; }
    public List<InvitationDetailDto> Invitations { get; set; }
}
