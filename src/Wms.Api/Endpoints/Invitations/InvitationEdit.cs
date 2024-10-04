using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Invitations;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Invitations;

public class InvitationEdit : Endpoint<InvitationEditDto>
{
    public InvitationRepo InvitationRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Invitations.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(InvitationEditDto req, CancellationToken ct) {
        var invitationId = Route<Guid>("Id");
        var invitation = await InvitationRepo.Find(invitationId);
        if (invitation == null) {
            await SendNotFoundAsync(ct);
        }
        UpdateProperties(invitation, req);
        await InvitationRepo.Update(invitation);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Invitation invitation, InvitationEditDto req) {
        invitation.Status = req.Outcome ?? invitation.Status;
    }
}
