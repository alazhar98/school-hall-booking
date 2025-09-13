using Microsoft.JSInterop;

namespace SchoolHallBooking.Services;

public class AuthService : IAuthService
{
    private readonly IJSRuntime _jsRuntime;
    private const string AdminUsername = "admin";
    private const string AdminPassword = "123456";
    private const string SessionKey = "admin_logged_in";

    public AuthService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<bool> ValidateAdminAsync(string username, string password)
    {
        var isValid = username == AdminUsername && password == AdminPassword;
        if (isValid)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", SessionKey, "true");
        }
        return isValid;
    }

    public async Task<bool> IsAdminLoggedIn()
    {
        try
        {
            var result = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", SessionKey);
            return result == "true";
        }
        catch
        {
            return false;
        }
    }

    public bool IsAdminLoggedInSync()
    {
        // For initial render, we'll assume not logged in and let the async method update it
        return false;
    }

    public async Task SetAdminLoggedIn(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.setItem", SessionKey, "true");
        }
        else
        {
            await _jsRuntime.InvokeVoidAsync("sessionStorage.removeItem", SessionKey);
        }
    }
}
