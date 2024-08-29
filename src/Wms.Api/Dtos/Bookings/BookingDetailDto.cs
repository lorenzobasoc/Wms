namespace Wms.Api.Dtos.Bookings;

public class BookingDetailDto
{
    public string Title { get; set; }
    public string Note { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid? SeatId { get; set; }
    public Guid? RoomId { get; set; }
}
