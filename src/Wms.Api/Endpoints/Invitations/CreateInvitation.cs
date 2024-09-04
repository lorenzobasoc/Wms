using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Invitations;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Invitations;

public class CreateInvitation : Endpoint<InvitationEditDto>
{
    public InvitationRepo InvitationRepo { get; set; }

    public override void Configure() {
        Post(ApiRoutes.Invitations.Edit);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(InvitationEditDto req, CancellationToken ct) {
        var invitation = req.ToEntity();
        await InvitationRepo.Create(invitation);
        await SendOkAsync(cancellation: ct);
    }
}
