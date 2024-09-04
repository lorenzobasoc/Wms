using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Tables;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Tables;

public class TableEdit : Endpoint<TableDetailDto>
{
    public TableRepo TableRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Tables.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(TableDetailDto req, CancellationToken ct) {
        var tableId = Route<Guid>(ApiRoutes.IdParam);
        var table = await TableRepo.Find(tableId);
        if (table == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        UpdateProperties(table, req);
        await TableRepo.Update(table);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Table table, TableDetailDto req) {
        table.Photo.Data = req.Photo ?? table.Photo.Data;
    }
}
