# Use the appropriate base image for ASP.NET Core
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . ./

RUN dotnet restore
RUN dotnet publish -c Release -o out

# Set the entry point for the application
ENTRYPOINT ["dotnet", "out/Restaurant.Docker.WebApp.dll"]