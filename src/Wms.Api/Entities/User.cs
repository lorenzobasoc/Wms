namespace Wms.Api.Entities;

public class User : DomainEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string? PasswordHash { get; set; }

    public File Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public List<Booking> Bookings { get; set; }

    public List<Invitation> SentInvitations { get; set; }
    public List<Invitation> ReceivedInvitations { get; set; }
}
