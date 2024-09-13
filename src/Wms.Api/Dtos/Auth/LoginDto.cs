namespace Wms.Api.Dtos.Auth;

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class LoginDtoValidator : Validator<LoginDto>
{
    public LoginDtoValidator() {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email empty");
            
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password empty");
    }
}
