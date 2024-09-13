namespace Wms.Api.Dtos.Auth;

public class RegisterWorkerDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}

public class RegisterWorkerDtoValidator : Validator<RegisterWorkerDto>
{
    public RegisterWorkerDtoValidator() {
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
    }
}
