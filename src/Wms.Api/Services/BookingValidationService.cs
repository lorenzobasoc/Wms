using Wms.Api.Dtos.Bookings;
using Wms.Api.Repositories;
using Wms.Api.Utilities;

namespace Wms.Api.Services;

public class BookingValidationService(BookingRepo bookingRepo) {

    public BookingRepo BookingRepo { get; set; } = bookingRepo;
    public ValidationContext ValidationContext { get; set; } = ValidationContext.Instance;

    public async Task Validate(BookingEditDto req) {
        if (req.RoomId == null && req.Seats.Count == 0) {
            ValidationContext.ThrowError("You have to reserve either a room or seat.");
        }
        if (req.RoomId != null && req.Seats.Count > 0) {
            ValidationContext.ThrowError("Can't reserve a room and a seat at the same time.");
        }
        if (req.RoomId == null) {
            await ValidateSeats(req.Seats, req.StartDate, req.EndDate);
        } else {
            await ValidateRoom(req.RoomId, req.StartDate, req.EndDate);
        }

        ValidationContext.ThrowIfAnyErrors();
    }

    private async Task ValidateRoom(Guid? roomId, DateTime startDate, DateTime endDate) {
        var bookings = await BookingRepo.FindBookingsForRoom(roomId, startDate, endDate);
        if (bookings.Count > 0) {
            var bookedDates = bookings
                .Select(b => DateFormatter.FormartRange(b.StartDate, b.EndDate))
                .ToList();
            var stringDates = string.Join(",", bookedDates);
            ValidationContext.AddError(nameof(BookingEditDto.RoomId), $"Room is already reserved in this dates: {stringDates}");
        }
    }

    private async Task ValidateSeats(List<SeatBookingDto> seats, DateTime startDate, DateTime endDate) {
        foreach (var seat in seats) {
            var bookings = await BookingRepo.FindBookingsForSeat(seat.SeatId, startDate, endDate);
            if (bookings.Count > 0) {
                var bookedDates = bookings
                    .Select(b => DateFormatter.FormartRange(b.StartDate, b.EndDate))
                    .ToList();
                var stringDates = string.Join(",", bookedDates);
                ValidationContext.AddError(nameof(BookingEditDto.Seats), $"Seat with id '{seat.SeatId}' is already reserved in this dates: {stringDates}");
            }
        }
    }
}