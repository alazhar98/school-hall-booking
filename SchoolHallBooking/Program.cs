using SchoolHallBooking.Components;
using SchoolHallBooking.Data;
using SchoolHallBooking.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add Entity Framework
builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Add Azure AD authentication (temporarily disabled for testing)
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// builder.Services.AddAuthorization();

var app = builder.Build();

// Ensure database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookingDbContext>();
    context.Database.EnsureCreated();
    
    // Update hall names to simple format and add 6th hall if it doesn't exist
    var halls = await context.Halls.ToListAsync();
    bool needsUpdate = false;
    
    foreach (var hall in halls)
    {
        var newName = $"القاعة {hall.Id}";
        if (hall.Name != newName)
        {
            hall.Name = newName;
            needsUpdate = true;
        }
    }
    
    // Add 6th hall if it doesn't exist
    var sixthHall = await context.Halls.FindAsync(6);
    if (sixthHall == null)
    {
        var newHall = new SchoolHallBooking.Models.Hall 
        { 
            Id = 6, 
            Name = "القاعة 6", 
            Capacity = 40, 
            Location = "Second Floor" 
        };
        context.Halls.Add(newHall);
        needsUpdate = true;
    }
    
    if (needsUpdate)
    {
        await context.SaveChangesAsync();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// app.UseAuthentication();
// app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Get port from environment variable (Render uses PORT)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Run($"http://0.0.0.0:{port}");
