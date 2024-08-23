namespace Wms.Api.Dtos.Users;

public class UserDetailDto : IdDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public byte[] Photo { get; set; }
}
