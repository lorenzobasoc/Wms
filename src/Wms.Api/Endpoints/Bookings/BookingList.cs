using Wms.Api.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class BookingList(BookingRepo bookingRepo) : EndpointWithoutRequest<BookingDetailDto[]>
{
    private readonly BookingRepo _bookingRepo = bookingRepo;

    public override void Configure() {
        Get(ApiRoutes.Bookings.List);
        Policies(AppPolicies.ADMIN_POLICY);
    }

    public override async Task<BookingDetailDto[]> HandleAsync(CancellationToken ct) {
        var bookings = await _bookingRepo.List();
        var res = bookings
            .Select(u => new BookingDetailDto {
                Title = u.Title,
                Note = u.Note,
                StartDate = u.StartDate,
                EndDate = u.EndDate,
                SeatId = u.SeatId,
                RoomId = u.RoomId,
            })
            .ToArray();
        return res;
    }
}
