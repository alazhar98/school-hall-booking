namespace SchoolHallBooking.Services;

public interface IAuthService
{
    Task<bool> ValidateAdminAsync(string username, string password);
    Task<bool> IsAdminLoggedIn();
    bool IsAdminLoggedInSync();
    Task SetAdminLoggedIn(bool isLoggedIn);
}
