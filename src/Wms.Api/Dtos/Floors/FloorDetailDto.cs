namespace Wms.Api.Dtos.Floors;

public class FloorDetailDto
{
    public string Name { get; set; }
    public string Description { get; set; }

    public List<ListItemDto> Rooms { get; set; }
}
