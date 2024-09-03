using Wms.Api.Constants.Bookings;

namespace Wms.Api.Dtos.Bookings;

public class BookingDetailDto
{
    public string Title { get; set; }
    public string Note { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid? SeatId { get; set; }
    public Guid? RoomId { get; set; }

    public Booking ToEntity() {
        return new Booking {
            Title = Title,
            Note = Note,
            StartDate = StartDate,
            EndDate = EndDate,
            RoomId = RoomId,
            SeatId = SeatId,
            Type = SeatId == null ? BookingTypes.ROOM : BookingTypes.SEAT,
        };
    }
}
