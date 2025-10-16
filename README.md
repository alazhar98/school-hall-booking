# نظام حجز القاعات المدرسية

نظام متكامل لإدارة حجز القاعات المدرسية مبني على ASP.NET Core (.NET 9) و Blazor Server مع دعم قاعدة بيانات SQLite.

## Features

- **Authentication & Authorization**: Azure AD (Microsoft Entra ID) integration with role-based access
- **Hall Management**: View available halls with capacity and location information
- **Booking System**: Teachers can book available halls for specific dates
- **Admin Interface**: Administrators can view all bookings and cancel reservations
- **Concurrency Handling**: Prevents double-booking with database-level unique constraints
- **Modern UI**: Responsive Bootstrap-based interface

## Roles

- **Teacher**: Can view available halls and create bookings
- **Admin**: Can view all bookings for a selected date and cancel bookings

## Technology Stack

- **.NET 8** - Latest .NET framework
- **Blazor Server** - Interactive web UI
- **Entity Framework Core** - Data access and ORM
- **Azure SQL Database** - Cloud database
- **Azure AD** - Authentication and authorization
- **Bootstrap 5** - UI framework

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or VS Code
- Azure subscription (for Azure AD and Azure SQL Database)
- SQL Server LocalDB (for local development)

## Setup Instructions

### 1. Clone and Build

```bash
git clone <repository-url>
cd SchoolHallBooking
dotnet restore
dotnet build
```

### 2. Database Configuration

#### Local Development
The application is configured to use SQL Server LocalDB by default. No additional setup is required for local development.

#### Azure SQL Database
Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=tcp:your-server.database.windows.net,1433;Initial Catalog=SchoolHallBooking;Persist Security Info=False;User ID=your-username;Password=your-password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}
```

### 3. Azure AD Configuration

1. **Register your application in Azure AD**:
   - Go to Azure Portal > Azure Active Directory > App registrations
   - Click "New registration"
   - Name: "School Hall Booking System"
   - Supported account types: "Accounts in this organizational directory only"
   - Redirect URI: Web - `https://localhost:5001/signin-oidc`

2. **Configure authentication**:
   - Go to Authentication > Add a platform > Web
   - Add redirect URI: `https://localhost:5001/signin-oidc`
   - Add logout URL: `https://localhost:5001/signout-callback-oidc`
   - Enable ID tokens

3. **Update appsettings.json**:
   ```json
   {
     "AzureAd": {
       "Instance": "https://login.microsoftonline.com/",
       "Domain": "yourdomain.onmicrosoft.com",
       "TenantId": "your-tenant-id",
       "ClientId": "your-client-id",
       "CallbackPath": "/signin-oidc",
       "SignedOutCallbackPath": "/signout-callback-oidc"
     }
   }
   ```

4. **Configure role claims**:
   - Go to Token configuration > Add optional claim > Access > groups
   - Go to App roles > Create app roles:
     - Name: "Teacher", Value: "Teacher", Description: "Can book halls"
     - Name: "Admin", Value: "Admin", Description: "Can manage all bookings"
   - Assign users to roles in Azure AD

### 4. Run the Application

```bash
dotnet run
```

Navigate to `https://localhost:5001` in your browser.

## Database Schema

### Halls Table
- `Id` (int, Primary Key)
- `Name` (string, Required, Max 100 chars)
- `Capacity` (int, Required, Min 1)
- `Location` (string, Optional, Max 200 chars)

### Bookings Table
- `Id` (int, Primary Key)
- `HallId` (int, Foreign Key to Halls)
- `BookingDate` (date, Required)
- `TeacherName` (string, Required, Max 100 chars)
- `CreatedAt` (datetime, Required)

### Unique Constraints
- `(HallId, BookingDate)` - Prevents double booking

## API Endpoints

The application uses Blazor Server with the following service methods:

### IBookingService
- `GetAvailableHallsAsync(DateTime date)` - Get halls available for a specific date
- `CreateBookingAsync(int hallId, DateTime date, string teacherName)` - Create a new booking
- `GetBookingsAsync(DateTime date)` - Get all bookings for a specific date (admin only)
- `DeleteBookingAsync(int bookingId)` - Delete a booking (admin only)
- `GetHallByIdAsync(int hallId)` - Get hall details by ID

## Deployment to Azure App Service

### 1. Create Azure Resources

1. **Azure SQL Database**:
   - Create a new SQL Database
   - Note the connection string

2. **Azure App Service**:
   - Create a new App Service (Windows)
   - Choose .NET 8 runtime

### 2. Configure Application Settings

In Azure App Service Configuration, add:

```
ConnectionStrings__DefaultConnection = "your-azure-sql-connection-string"
AzureAd__Instance = "https://login.microsoftonline.com/"
AzureAd__Domain = "yourdomain.onmicrosoft.com"
AzureAd__TenantId = "your-tenant-id"
AzureAd__ClientId = "your-client-id"
AzureAd__CallbackPath = "/signin-oidc"
AzureAd__SignedOutCallbackPath = "/signout-callback-oidc"
```

### 3. Update Azure AD Redirect URIs

Add your production URL to Azure AD app registration:
- `https://your-app-name.azurewebsites.net/signin-oidc`
- `https://your-app-name.azurewebsites.net/signout-callback-oidc`

### 4. Deploy

```bash
dotnet publish -c Release -o ./publish
# Deploy the publish folder to Azure App Service
```

## Security Features

- **Authentication**: Azure AD integration
- **Authorization**: Role-based access control
- **Data Protection**: HTTPS enforcement
- **Concurrency**: Database-level unique constraints prevent double booking
- **Input Validation**: Model validation and sanitization

## Error Handling

- **Concurrency Conflicts**: Graceful handling of double-booking attempts
- **Validation Errors**: User-friendly error messages
- **Database Errors**: Comprehensive logging and error reporting
- **Authentication Errors**: Proper redirect to login page

## Development Notes

- The application uses Entity Framework Core migrations
- Database is automatically created on first run
- Seed data includes sample halls
- All dates are normalized to midnight to prevent timezone issues
- User information comes from Azure AD claims

## Troubleshooting

### Common Issues

1. **Authentication not working**:
   - Verify Azure AD configuration
   - Check redirect URIs match exactly
   - Ensure user has proper role assignments

2. **Database connection issues**:
   - Verify connection string format
   - Check firewall rules for Azure SQL
   - Ensure database exists

3. **Role authorization not working**:
   - Verify app roles are created in Azure AD
   - Check user role assignments
   - Ensure token configuration includes groups claim
