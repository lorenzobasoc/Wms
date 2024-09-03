using Wms.Api.Constants.Authorization;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Tables;

public class DeleteTable(TableRepo tableRepo) : EndpointWithoutRequest
{
    private readonly TableRepo _tableRepo = tableRepo;

    public override void Configure() {
        Delete(ApiRoutes.Tables.Delete + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var tableId = Route<Guid>(ApiRoutes.IdParam);
        var table = await _tableRepo.Find(tableId);
        if (table == null) {
            // HANDLE_ERROR -> table non trovato 404 + mex ? c'è single or throw
        }
        
        await _tableRepo.Delete(table);
        await SendOkAsync(cancellation: ct);
    }
}
