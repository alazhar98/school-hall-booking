namespace SchoolHallBooking.Services;

public interface ITimeZoneService
{
    /// <summary>
    /// Gets the Oman timezone (Asia/Muscat)
    /// </summary>
    TimeZoneInfo OmanTimeZone { get; }
    
    /// <summary>
    /// Converts a UTC DateTime to Oman time
    /// </summary>
    DateTime ConvertFromUtc(DateTime utcDateTime);
    
    /// <summary>
    /// Converts a DateTime to UTC (assuming it's in Oman time)
    /// </summary>
    DateTime ConvertToUtc(DateTime omanDateTime);
    
    /// <summary>
    /// Gets the current date in Oman timezone
    /// </summary>
    DateTime GetCurrentDate();
    
    /// <summary>
    /// Gets the current date and time in Oman timezone
    /// </summary>
    DateTime GetCurrentDateTime();
    
    /// <summary>
    /// Converts a date to Oman timezone (for display)
    /// </summary>
    DateTime ConvertToOmanTime(DateTime dateTime);
}
