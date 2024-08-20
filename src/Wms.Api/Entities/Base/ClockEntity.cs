namespace Wms.Api.Entities.Base;

public abstract class ClockEntity : IClockEntity
{
    public DateTime Added { get; set; }
    public DateTime Modified { get; set; }
}
