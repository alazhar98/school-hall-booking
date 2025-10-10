namespace SchoolHallBooking.Services
{
    public interface IAdminAuthService
    {
        Task<bool> ValidateAdminAsync(string username, string password);
        Task<bool> IsAdminLoggedInAsync();
        Task SetAdminLoggedInAsync(bool isLoggedIn);
        Task LogoutAdminAsync();
    }
}
