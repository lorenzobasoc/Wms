using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;

namespace Wms.Api.Endpoints.Bookings;

public class BookingEdit : Endpoint<BookingEditDto>
{
    public BookingRepo BookingRepo { get; set; }
    public UserRepo UserRepo { get; set; }

    public override void Configure() {
        Put(ApiRoutes.Bookings.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(BookingEditDto req, CancellationToken ct) {
        var bookingId = Route<Guid>(ApiRoutes.IdParam);
        var userId = await UserRepo.GetUserId(User.Identity.Name);
        var booking = await BookingRepo.Find(bookingId);
        if (booking == null) {
            // HANDLE_ERROR -> utente non registrato 401 + mex ? 
        }
        if  (booking.HasUser(userId)) {
            // HANDLE_ERROR: throw forbidden o null?
        }
        UpdateProperties(booking, req);
        await BookingRepo.Update(booking);
        await SendOkAsync(cancellation: ct);
    }

    private static void UpdateProperties(Booking booking, BookingEditDto req) {
        booking.Title = req.Title ?? booking.Title;
        booking.Note = req.Note ?? booking.Note;
        booking.Seats = req.Seats == null 
            ? booking.Seats 
            : req.Seats
                .Select(s => s.ToEntity())
                .ToList();
        booking.Users = req.Users == null
            ? booking.Users
            : req.Users
                .Select(u => u.ToEntity())
                .ToList();
    }
}
