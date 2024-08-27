namespace Wms.Api.Dtos.Seats;

public class SeatDetaiDto
{
    public string Name { get; set; }
    public byte[] Photo { get; set; }
    public Guid TableId { get; set; }

    public Seat ToEntity(Guid tableId) {
        var photo = new AppFile { Data = Photo };
        return new Seat {
            TableId = tableId,
            Name = Name,
            Photo = photo,
        };
    }
}
