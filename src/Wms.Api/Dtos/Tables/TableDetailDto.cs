using Wms.Api.Dtos.Seats;

namespace Wms.Api.Dtos.Tables;

public class TableDetailDto
{
    public Guid RoomId { get; set; }
    public byte[] Photo { get; set; }
    
    public SeatDetailDto[] Seats { get; set; }

    public Table ToEntity() {
        var photo = Photo == null ? null : new AppFile { Data = Photo };
        return new Table {
            RoomId = RoomId,
            Photo = photo,
            Type = null,
        };
    }
}
