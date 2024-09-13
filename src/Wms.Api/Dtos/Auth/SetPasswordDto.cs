namespace Wms.Api.Dtos.Auth;

public class SetPasswordDto
{
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class SetPasswordDtoValidator : Validator<SetPasswordDto>
{
    public SetPasswordDtoValidator() {
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
