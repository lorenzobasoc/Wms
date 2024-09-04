using Wms.Api.Constants.Invitations;
using Wms.Api.Dtos.Invitations;

namespace Wms.Api.Entities;

public class Invitation : DomainEntity
{
    public Invitation() {
        Status = InvitationStatus.SENT;
    }

    public string Message { get; set; }
    public string Status { get; set; }

    public User FromUser { get; set; }
    public Guid FromUserId { get; set; }
    
    public User ToUser { get; set; }
    public Guid ToUserId { get; set; }

    public Table Table { get; set; }
    public Guid? TableId { get; set; }

    public Booking Booking { get; set; }
    public Guid? BookingId { get; set; }

    public InvitationDetailDto ToinvitationDetailDto() {
        return new InvitationDetailDto {
            Message = Message,
            Outcome = Status,
            FromUserId = FromUserId,
            ToUserId = ToUserId,
            TableId = TableId,
            BookingId = BookingId,
        };
    }
}
