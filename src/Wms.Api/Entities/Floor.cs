using Wms.Api.Dtos;
using Wms.Api.Dtos.Floors;

namespace Wms.Api.Entities;

public class Floor : DomainEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Room> Rooms { get; set; }

    public FloorDetailDto ToFloorDetail() {
        return new FloorDetailDto {
            Name = Name,
            Description = Description,
            Rooms = Rooms
                .Select(r => 
                    new ListItemDto {
                        Id = r.Id,
                        Description = r.Name,
                    }
                ).ToList()
        };
    }
}
