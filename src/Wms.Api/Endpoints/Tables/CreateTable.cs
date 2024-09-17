using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Tables;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Tables;

public class CreateTable : Endpoint<TableDetailDto>
{
    public TableRepo TableRepo { get; set; }
    public SeatRepo SeatRepo { get; set; }

    public override void Configure() {
        Post(ApiRoutes.Tables.Edit);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(TableDetailDto req, CancellationToken ct) {
        var table = req.ToEntity();
        var seats = req.Seats?
            .Select(s => s.ToEntity(table.Id))
            .ToList();
        await TableRepo.Create(table);
        if (seats != null) {
            await SeatRepo.Create(seats);
        }
        await SendOkAsync(cancellation: ct);
    }
}
