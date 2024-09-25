namespace Wms.Api.Utilities;

public static class DateFormatter
{
    public static string FormartRange(DateTime startDate, DateTime endDate) {
        return $"[{startDate:yyyy-MM-dd HH:mm}] - [{endDate:yyyy-MM-dd HH:mm}]";  
    }
}
