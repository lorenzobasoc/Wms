using Wms.Api.Constants.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Tables;

public class DeleteTable : EndpointWithoutRequest
{
    public TableRepo TableRepo { get; set; }

    public override void Configure() {
        Delete(ApiRoutes.Tables.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var tableId = Route<Guid>(ApiRoutes.IdParam);
        var table = await TableRepo.Find(tableId);
        if (table == null) {
            await SendNotFoundAsync(ct);
        }
        await TableRepo.Delete(table);
        await SendOkAsync(cancellation: ct);
    }
}
