using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Invitations;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Invitations;

public class InvitationList : EndpointWithoutRequest<List<InvitationDetailDto>>
{
    public InvitationRepo InvitationRepo { get; set; }
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Get(ApiRoutes.Invitations.List);
        Policies(AppPolicies.WORKER_POLICY);
    }

    public override async Task<List<InvitationDetailDto>> HandleAsync(CancellationToken ct) {
        var userId = await UserRepo.GetUserId(User.Identity.Name);
        var invitations = await InvitationRepo.List(userId);
        var res = invitations
            .Select(u => u.ToinvitationDetailDto())
            .ToList();
        return res;
    }
}
