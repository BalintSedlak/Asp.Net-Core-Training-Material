#Build Stage

# Use the appropriate base image for ASP.NET Core
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /source

COPY . .

RUN dotnet restore "./Restaurant.Docker.WebApp/Restaurant.Docker.WebApp.csproj"
RUN dotnet publish "./Restaurant.Docker.WebApp/Restaurant.Docker.WebApp.csproj" -c release -o /app --no-restore

#Runtime Stage
From mcr.microsoft.com/dotnet/sdk:7.0 AS serve-env
WORKDIR /app
Copy --from=build-env /app ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Restaurant.Docker.WebApp.dll"]