using Microsoft.JSInterop;
using Microsoft.EntityFrameworkCore;
using SchoolHallBooking.Data;
using SchoolHallBooking.Models;
using System.Text.Json;

namespace SchoolHallBooking.Services
{
    public class AuthService : IAuthService
    {
        private readonly BookingDbContext _context;
        private readonly IJSRuntime _jsRuntime;
        private const string AUTH_KEY = "school_auth";

        public event Action? OnAuthStateChanged;

        public AuthService(BookingDbContext context, IJSRuntime jsRuntime)
        {
            _context = context;
            _jsRuntime = jsRuntime;
        }

        public async Task<Employee?> LoginAsync(string employeeId, string password)
        {
            try
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.Password == password && e.IsActive);

                if (employee != null)
                {
                    // Store authentication data in localStorage
                    var authData = new
                    {
                        EmployeeId = employee.EmployeeId,
                        Name = employee.Name,
                        LoginTime = DateTime.Now
                    };

                    await _jsRuntime.InvokeVoidAsync("localStorage.setItem", AUTH_KEY, JsonSerializer.Serialize(authData));
                    
                    // Notify subscribers that auth state has changed
                    OnAuthStateChanged?.Invoke();
                }

                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Login error: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                var authData = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", AUTH_KEY);
                return !string.IsNullOrEmpty(authData);
            }
            catch
            {
                return false;
            }
        }

        public async Task<Employee?> GetCurrentUserAsync()
        {
            try
            {
                var authData = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", AUTH_KEY);
                if (string.IsNullOrEmpty(authData))
                    return null;

                var authInfo = JsonSerializer.Deserialize<JsonElement>(authData);
                var employeeId = authInfo.GetProperty("EmployeeId").GetString() ?? string.Empty;

                if (string.IsNullOrEmpty(employeeId))
                    return null;

                return await _context.Employees
                    .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && e.IsActive);
            }
            catch
            {
                return null;
            }
        }

        public async Task LogoutAsync()
        {
            try
            {
                await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", AUTH_KEY);
                
                // Notify subscribers that auth state has changed
                OnAuthStateChanged?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Logout error: {ex.Message}");
            }
        }

        public async Task<bool> IsAuthorizedAsync(string? requiredRole = null)
        {
            var user = await GetCurrentUserAsync();
            if (user == null)
                return false;

            if (string.IsNullOrEmpty(requiredRole))
                return true;

            return true; // Since we removed Role, all authenticated users are authorized
        }
    }
}