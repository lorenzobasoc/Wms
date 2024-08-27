using Wms.Api.Dtos.Seats;

namespace Wms.Api.Dtos.Tables;

public class TableDetailDto
{
    public Guid RoomId { get; set; }
    
    public SeatDetaiDto[] Seats { get; set; }
}
