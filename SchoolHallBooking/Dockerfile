# Use the official .NET 9.0 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 9.0 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SchoolHallBooking.csproj", "."]
RUN dotnet restore "SchoolHallBooking.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "SchoolHallBooking.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolHallBooking.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolHallBooking.dll"]