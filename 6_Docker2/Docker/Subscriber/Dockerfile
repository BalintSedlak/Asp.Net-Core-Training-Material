#Build Stage

# Use the appropriate base image for ASP.NET Core
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /source

COPY . .

RUN dotnet restore "./Subscriber/Subscriber.csproj"
RUN dotnet publish "./Subscriber/Subscriber.csproj" -c debug -o /app --no-restore

#Runtime Stage
From mcr.microsoft.com/dotnet/sdk:7.0 AS serve-env
WORKDIR /app
Copy --from=build-env /app ./

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_CLI_TELEMETRY_OPTOUT=true

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Subscriber.dll"]