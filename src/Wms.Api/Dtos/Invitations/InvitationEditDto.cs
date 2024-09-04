namespace Wms.Api.Dtos.Invitations;

public class InvitationEditDto
{
    public string Message { get; set; }
    public string Outcome { get; set; }
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
    public Guid? TableId { get; set; }
    public Guid? BookingId { get; set; }

    public Invitation ToEntity() {
        return new Invitation {
            Message = Message,
            FromUserId = FromUserId,
            ToUserId = ToUserId,
            TableId = TableId,
            BookingId = BookingId,
        };
    }
}
