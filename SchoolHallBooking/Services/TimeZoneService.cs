namespace SchoolHallBooking.Services;

public class TimeZoneService : ITimeZoneService
{
    private readonly TimeZoneInfo _omanTimeZone;
    private readonly ILogger<TimeZoneService> _logger;

    public TimeZoneService(ILogger<TimeZoneService> logger)
    {
        _logger = logger;
        
        try
        {
            _omanTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Muscat");
        }
        catch (TimeZoneNotFoundException)
        {
            // Fallback to UTC+4 if Asia/Muscat is not found
            _logger.LogWarning("Asia/Muscat timezone not found, using UTC+4 offset");
            _omanTimeZone = TimeZoneInfo.CreateCustomTimeZone(
                "Asia/Muscat",
                TimeSpan.FromHours(4),
                "Oman Standard Time",
                "Oman Standard Time");
        }
    }

    public TimeZoneInfo OmanTimeZone => _omanTimeZone;

    public DateTime ConvertFromUtc(DateTime utcDateTime)
    {
        try
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, _omanTimeZone);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error converting UTC time to Oman time: {UtcDateTime}", utcDateTime);
            return utcDateTime.AddHours(4); // Fallback to UTC+4
        }
    }

    public DateTime ConvertToUtc(DateTime omanDateTime)
    {
        try
        {
            // Assume the input is in Oman time and convert to UTC
            return TimeZoneInfo.ConvertTimeToUtc(omanDateTime, _omanTimeZone);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error converting Oman time to UTC: {OmanDateTime}", omanDateTime);
            return omanDateTime.AddHours(-4); // Fallback to UTC-4
        }
    }

    public DateTime GetCurrentDate()
    {
        var utcNow = DateTime.UtcNow;
        var omanTime = ConvertFromUtc(utcNow);
        return omanTime.Date;
    }

    public DateTime GetCurrentDateTime()
    {
        var utcNow = DateTime.UtcNow;
        return ConvertFromUtc(utcNow);
    }

    public DateTime ConvertToOmanTime(DateTime dateTime)
    {
        // If the DateTime is already in UTC, convert it
        if (dateTime.Kind == DateTimeKind.Utc)
        {
            return ConvertFromUtc(dateTime);
        }
        
        // If it's unspecified, assume it's in Oman time
        if (dateTime.Kind == DateTimeKind.Unspecified)
        {
            return dateTime;
        }
        
        // If it's local time, convert to UTC first, then to Oman time
        var utcTime = dateTime.ToUniversalTime();
        return ConvertFromUtc(utcTime);
    }
}
