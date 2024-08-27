namespace Wms.Api.Dtos.Floors;

public class FloorEditDto
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Floor ToEntity() {
        return new Floor {
            Name = Name,
            Description = Description,
        };
    }
}
