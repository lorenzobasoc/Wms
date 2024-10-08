using Wms.Api.Dtos.Users;

namespace Wms.Api.Entities;

public class User : DomainEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string? PasswordHash { get; set; }
    public bool Disabled { get; set; }
    public DateTime? DisablingDate { get; set; }

    public AppFile Photo { get; set; }
    public Guid? PhotoId { get; set; }

    public List<UserBooking> Bookings { get; set; }

    public List<Invitation> SentInvitations { get; set; }
    public List<Invitation> ReceivedInvitations { get; set; }

    public UserDetailDto ToUserDetail() {
        return new UserDetailDto {
            Name = Name,
            Surname = Surname,
            Role = Role,
            Email = Email,
            Photo = Photo?.Data,
        };
    }
}
