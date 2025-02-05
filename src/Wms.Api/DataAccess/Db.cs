using Wms.Api.Extensions;
using AppFile = Wms.Api.Entities.AppFile;

namespace Wms.Api.DataAccess;

public class Db : DbContext
{
    public Db(DbContextOptions<Db> options) : base(options) {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<User> Users { get; set; }   
    public DbSet<Booking> Bookings { get; set; }   
    public DbSet<AppFile> AppFiles { get; set; }   
    public DbSet<Floor> Floors { get; set; }   
    public DbSet<Room> Rooms { get; set; }   
    public DbSet<Table> Tables { get; set; }   
    public DbSet<Seat> Seats { get; set; }   
    public DbSet<Invitation> Invitations { get; set; }   

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        ConfigureUsers(builder);
        ConfigureBookings(builder);
        ConfigureFloors(builder);
        ConfigureRooms(builder);
        ConfigureTables(builder);
    }

    private static void ConfigureTables(ModelBuilder builder) {
        builder.OneToOne<Table, AppFile>(t => t.Photo, f => f.Table);
        builder.OneToMany<Table, Invitation>(t => t.Invitations, i => i.Table);
        builder.OneToMany<Table, Seat>(t => t.Seats, s => s.Table);
    }

    private static void ConfigureRooms(ModelBuilder builder) {
        builder.OneToOne<Room, AppFile>(r => r.Photo, f => f.Room);
        builder.OneToMany<Room, Table>(r => r.Tables, t => t.Room);
    }

    private static void ConfigureFloors(ModelBuilder builder) {
        builder.OneToMany<Floor, Room>(f => f.Rooms, r => r.Floor);
    }

    private static void ConfigureBookings(ModelBuilder builder) {
        builder.ManyToMany<User, UserBooking, Booking>(
            b => b.User, u => u.Bookings, 
            b => b.Booking, s => s.Users
        );
        builder.ManyToMany<Seat, SeatBooking, Booking>(
            b => b.Seat, u => u.Bookings, 
            b => b.Booking, s => s.Seats
        );
        builder.OneToMany<Booking, Invitation>(b => b.Invitations, i => i.Booking);
    }

    private static void ConfigureUsers(ModelBuilder builder) {
        builder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        builder.OneToOne<User, AppFile>(u => u.Photo, f => f.User);
        builder.OneToMany<User, Invitation>(u => u.ReceivedInvitations, i => i.ToUser);
        builder.OneToMany<User, Invitation>(u => u.SentInvitations, i => i.FromUser);
    }

    public override Task<int> SaveChangesAsync(CT ct = default) {
        var now = DateTime.Now;
        foreach (var entry in ChangeTracker.Entries()) {
            if (entry.Entity is not IClockEntity clockEntity) {
                continue;
            }
            if (entry.State == EntityState.Added) {
                clockEntity.Added = now;
                clockEntity.Modified = now;
            } else if (entry.State == EntityState.Modified) {
                clockEntity.Modified = now;
            }
        }
        return base.SaveChangesAsync(ct);
    }
}
