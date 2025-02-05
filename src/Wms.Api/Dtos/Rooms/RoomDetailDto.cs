using Wms.Api.Dtos.Tables;

namespace Wms.Api.Dtos.Rooms;

public class RoomDetailDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public byte[] Photo { get; set; }
    public Guid FloorId { get; set; }

    public TableDetailDto[] Tables { get; set; }
}
