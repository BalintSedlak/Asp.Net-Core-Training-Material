# Use the appropriate base image for ASP.NET Core
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /source

COPY . .

RUN dotnet restore "./Restaurant.Docker.WebApp/Restaurant.Docker.WebApp.csproj"
RUN dotnet publish "./Restaurant.Docker.WebApp/Restaurant.Docker.WebApp.csproj" -c release -o /app --no-restore

# Set the entry point for the application
ENTRYPOINT ["dotnet", "out/Restaurant.Docker.WebApp.dll"]