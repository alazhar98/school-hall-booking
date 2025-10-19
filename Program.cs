using SchoolHallBooking.Components;
using SchoolHallBooking.Data;
using SchoolHallBooking.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using ClosedXML.Excel;
using Microsoft.AspNetCore.StaticFiles;
using SchoolHallBooking.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(options =>
    {
        options.DetailedErrors = true;
    });

// Add Entity Framework
builder.Services.AddDbContext<BookingDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (connectionString != null && (connectionString.Contains("Server=") || connectionString.Contains("mysql")))
    {
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
    else
    {
        options.UseSqlite(connectionString ?? "Data Source=App_Data/SchoolHallBooking.db");
    }
});

// Stats are now stored in the same SQLite DB via BookingDbContext

// Add services
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IExportService, ExportService>();
builder.Services.AddScoped<ITimeZoneService, TimeZoneService>();
builder.Services.AddScoped<IStatsService, StatsService>();
builder.Services.AddScoped<IDutyScheduleService, DutyScheduleService>();
builder.Services.AddScoped<IAdminAuthService, AdminAuthService>();
builder.Services.AddScoped<IActivitySupervisorService, ActivitySupervisorService>();
builder.Services.AddScoped<IClassLeaderService, ClassLeaderService>();
builder.Services.AddScoped<ISchoolPlanService, SchoolPlanService>();
builder.Services.AddScoped<IDailyPlanService, DailyPlanService>();
builder.Services.AddScoped<ISupervisoryVisitService, SupervisoryVisitService>();
builder.Services.AddScoped<IProfessionalDevelopmentService, ProfessionalDevelopmentService>();
builder.Services.AddScoped<IAcademicAchievementService, AcademicAchievementService>();
builder.Services.AddScoped<ISchoolPerformanceDevelopmentService, SchoolPerformanceDevelopmentService>();
builder.Services.AddScoped<ITeachersAttendanceService, TeachersAttendanceService>();

// Add Azure AD authentication (temporarily disabled for testing)
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// builder.Services.AddAuthorization();

var app = builder.Build();

        // Ensure database is created and seeded
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<BookingDbContext>();

            // Ensure data directory exists for VPS deployment
            var dbPath = context.Database.GetConnectionString();
            if (dbPath != null && dbPath.Contains("Data Source="))
            {
                var rawPath = dbPath.Replace("Data Source=", "").Trim();
                try
                {
                    // Only create directories within the app content root to avoid permission issues (e.g., /var/www)
                    var targetDir = Path.GetDirectoryName(rawPath);
                    if (!string.IsNullOrEmpty(targetDir))
                    {
                        if (!Path.IsPathRooted(rawPath) || targetDir.StartsWith(app.Environment.ContentRootPath, StringComparison.Ordinal))
                        {
                            if (!Directory.Exists(targetDir))
                            {
                                Directory.CreateDirectory(targetDir);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Startup] Skipping DB directory creation: {ex.Message}");
                }
            }

            // Initialize database with proper schema
            await DatabaseInitializer.InitializeDatabaseAsync(context);

            // Stats tables are part of BookingDbContext (SQLite). Migrate handled above.
        }

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

// app.UseAuthentication();
// app.UseAuthorization();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// For Azure App Service, let the platform handle the URL configuration
// Export endpoints for stats (Excel)
app.MapGet("/export/stats/staff", async (IStatsService statsService) =>
{
    string GetRoleLabel(SchoolHallBooking.Models.StaffRole role) => role switch
    {
        SchoolHallBooking.Models.StaffRole.Administrative => "الوظائف الإدارية",
        SchoolHallBooking.Models.StaffRole.Support => "الوظائف المساندة",
        SchoolHallBooking.Models.StaffRole.Teaching => "الهيئة التعليمية",
        SchoolHallBooking.Models.StaffRole.DailyWageTeachers => "معلمي الأجر اليومي",
        SchoolHallBooking.Models.StaffRole.Workers => "العمال",
        SchoolHallBooking.Models.StaffRole.Guards => "الحراس",
        SchoolHallBooking.Models.StaffRole.SchoolBusDrivers => "سائقي النقل المدرسي",
        _ => role.ToString()
    };

    var data = await statsService.GetStaffAsync();
    using var workbook = new XLWorkbook();
    var ws = workbook.Worksheets.Add("الإحصائية العامة للمدرسة");
    ws.RightToLeft = true;
    ws.Cell(1, 1).Value = "الوظيفة";
    ws.Cell(1, 2).Value = "العدد";
    for (int i = 0; i < data.Count; i++)
    {
        ws.Cell(i + 2, 1).Value = GetRoleLabel(data[i].Role);
        ws.Cell(i + 2, 2).Value = data[i].Count;
    }
    ws.Cell(data.Count + 2, 1).Value = "المجموع";
    ws.Cell(data.Count + 2, 2).Value = data.Sum(x => x.Count);
    ws.Columns().AdjustToContents();
    using var stream = new MemoryStream();
    workbook.SaveAs(stream);
    var bytes = stream.ToArray();
    return Results.File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"staff-stats-{DateTime.UtcNow:yyyyMMdd}.xlsx");
});

app.MapGet("/export/stats/regular", async (IStatsService statsService) =>
{
    var data = await statsService.GetRegularStudentsAsync();
    using var workbook = new XLWorkbook();
    var ws = workbook.Worksheets.Add("الطلبة النظاميون");
    ws.RightToLeft = true;
    ws.Cell(1, 1).Value = "الشعبة";
    ws.Cell(1, 2).Value = "العدد";
    for (int i = 0; i < data.Count; i++)
    {
        ws.Cell(i + 2, 1).Value = data[i].Division;
        ws.Cell(i + 2, 2).Value = data[i].Count;
    }
    ws.Cell(data.Count + 2, 1).Value = "المجموع";
    ws.Cell(data.Count + 2, 2).Value = data.Sum(x => x.Count);
    ws.Columns().AdjustToContents();
    using var stream = new MemoryStream();
    workbook.SaveAs(stream);
    var bytes = stream.ToArray();
    return Results.File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"regular-students-{DateTime.UtcNow:yyyyMMdd}.xlsx");
});

app.MapGet("/export/stats/hearing", async (IStatsService statsService) =>
{
    var data = await statsService.GetHearingImpairedAsync();
    using var workbook = new XLWorkbook();
    var ws = workbook.Worksheets.Add("طلبة الدمج السمعي");
    ws.RightToLeft = true;
    ws.Cell(1, 1).Value = "الصف";
    ws.Cell(1, 2).Value = "العدد";
    for (int i = 0; i < data.Count; i++)
    {
        ws.Cell(i + 2, 1).Value = data[i].Grade;
        ws.Cell(i + 2, 2).Value = data[i].Count;
    }
    ws.Cell(data.Count + 2, 1).Value = "المجموع";
    ws.Cell(data.Count + 2, 2).Value = data.Sum(x => x.Count);
    ws.Columns().AdjustToContents();
    using var stream = new MemoryStream();
    workbook.SaveAs(stream);
    var bytes = stream.ToArray();
    return Results.File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"hearing-impaired-{DateTime.UtcNow:yyyyMMdd}.xlsx");
});

app.Run();
