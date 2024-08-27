
namespace Wms.Api.Dtos.Rooms;

public class RoomEditDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public byte[] Photo { get; set; }

    public Room ToEntity() {
        var photo = Photo == null ? null : new Entities.AppFile { Data = Photo };
        return new Room { 
            Name = Name,
            Description = Description,
            Photo = photo
        };
    }
}
