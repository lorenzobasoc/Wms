namespace Wms.Api.Dtos.Auth;

public class RegisterDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class RegisterDtoValidator : Validator<RegisterDto>
{
    public RegisterDtoValidator() {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name empty");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("Surname empty");
            
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email empty")
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password empty");
            
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm password empty")
            .Equal(x => x.Password)
            .WithMessage("Confirm password is different from password");
    }
}
