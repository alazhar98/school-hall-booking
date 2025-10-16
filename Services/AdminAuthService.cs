using Microsoft.JSInterop;

namespace SchoolHallBooking.Services
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string ADMIN_AUTH_KEY = "admin_auth";

        public AdminAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> ValidateAdminAsync(string username, string password)
        {
            // Simple admin validation - you can make this more secure
            if (username == "admin" && password == "123456")
            {
                await SetAdminLoggedInAsync(true);
                return true;
            }
            return false;
        }

        public async Task<bool> IsAdminLoggedInAsync()
        {
            try
            {
                var authData = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", ADMIN_AUTH_KEY);
                return !string.IsNullOrEmpty(authData) && authData == "true";
            }
            catch
            {
                return false;
            }
        }

        public async Task SetAdminLoggedInAsync(bool isLoggedIn)
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.setItem", ADMIN_AUTH_KEY, isLoggedIn.ToString().ToLower());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SetAdminLoggedIn error: {ex.Message}");
            }
        }

        public async Task LogoutAdminAsync()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", ADMIN_AUTH_KEY);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LogoutAdmin error: {ex.Message}");
            }
        }
    }
}
