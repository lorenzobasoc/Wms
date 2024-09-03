namespace Wms.Api.Dtos.Invitations;

public class InvitationDetailDto
{
    public string Message { get; set; }
    public string Outcome { get; set; }
    public Guid FromUserId { get; set; }
    public Guid ToUserId { get; set; }
    public Guid? TableId { get; set; }
    public Guid? BookingId { get; set; }
}
