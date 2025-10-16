using SchoolHallBooking.Models;

namespace SchoolHallBooking.Services
{
    public interface IAuthService
    {
        Task<Employee?> LoginAsync(string employeeId, string password);
        Task<bool> IsAuthenticatedAsync();
        Task<Employee?> GetCurrentUserAsync();
        Task LogoutAsync();
        Task<bool> IsAuthorizedAsync(string? requiredRole = null);
    }
}