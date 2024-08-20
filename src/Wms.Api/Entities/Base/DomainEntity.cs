namespace Wms.Api.Entities.Base;

public class DomainEntity : ClockEntity
{
    public Guid Id { get; set; }

    public DomainEntity() {
        Id = Guid.NewGuid();
    }
}
