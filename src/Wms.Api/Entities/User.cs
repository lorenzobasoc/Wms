namespace Wms.Api.Entities;

public class User : DomainEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityStamp { get; set; }

    public File Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public List<Booking> Bookings { get; set; }

    public List<Invitation> Invitations { get; set; }
}
