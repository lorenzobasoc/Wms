using Wms.Api.Constants.Authorization;
using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;
using Wms.Api.Services;

namespace Wms.Api.Endpoints.Bookings;

public class BookingEdit : Endpoint<BookingEditDto>
{
    public BookingRepo BookingRepo { get; set; }
    public UserRepo UserRepo { get; set; }
    public BookingValidationService BookingValidationService { get; set; }


    public override void Configure() {
        Put(ApiRoutes.Bookings.Edit + ApiRoutes.IdParam);
        Policies([AppPolicies.WORKER_POLICY]);
    }

    public override async Task HandleAsync(BookingEditDto req, CancellationToken ct) {
        var bookingId = Route<Guid>("Id");
        var userId = await UserRepo.GetUserId(User.Identity.Name);
        var booking = await BookingRepo.Find(bookingId);
        if (booking == null) {
            await SendNotFoundAsync(ct);
        }
        if (!booking.HasUser(userId)) {
           await SendForbiddenAsync(ct);
        }
        
        await BookingValidationService.Validate(req);

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
