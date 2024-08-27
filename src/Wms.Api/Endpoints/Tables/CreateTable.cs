using Wms.Api.Authorization;
using Wms.Api.Dtos.Tables;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Tables;

public class CreateTable(TableRepo tableRepo, SeatRepo seatRepo) : Endpoint<TableDetailDto>
{
    private readonly TableRepo _tableRepo = tableRepo;
    private readonly SeatRepo _seatRepo = seatRepo;

    public override void Configure() {
        Post(ApiRoutes.Tables.Edit);
        Policies([AppPolicies.ADMIN_POLICY]);
    }

    public override async Task HandleAsync(TableDetailDto req, CancellationToken ct) {
        var table = req.ToEntity();
        var seats = req.Seats?
            .Select(s => s.ToEntity(table.Id))
            .ToList();
        await _tableRepo.Create(table);
        if (seats != null) {
            await _seatRepo.Create(seats);
        }
        await SendOkAsync(cancellation: ct);
    }
}
