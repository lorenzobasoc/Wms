// using Wms.Api.Authorization;
// using Wms.Api.Dtos.Seats;
// using Wms.Api.Repositories;

// namespace Wms.Api.Endpoints.Seats;

// public class CreateSeat(SeatRepo tableRepo, SeatRepo seatRepo) : Endpoint<SeatDetailDto>
// {
//     private readonly SeatRepo _tableRepo = tableRepo;
//     private readonly SeatRepo _seatRepo = seatRepo;

//     public override void Configure() {
//         Post(ApiRoutes.Seats.Edit);
//         Policies([AppPolicies.ADMIN_POLICY]);
//     }

//     public override async Task HandleAsync(SeatDetailDto req, CancellationToken ct) {
//         var table = req.ToEntity();
//         var seats = req.Seats?
//             .Select(s => s.ToEntity(table.Id))
//             .ToList();
//         await _tableRepo.Create(table);
//         if (seats != null) {
//             await _seatRepo.Create(seats);
//         }
//         await SendOkAsync(cancellation: ct);
//     }
// }
