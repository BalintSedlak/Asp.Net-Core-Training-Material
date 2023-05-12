# RestApiDemo

## Developer setup

### Developer environment
1. Sql express
2. Sql Server Management Studio
3. Visual Studio
4. Visual Studio Code

### Database
1. Open project in Visual Studio
2. Open the Package Manager Console
3. Select a project with "DbContext".cs file for "Default project"
4. In case of Clean Architecture project: Run "dotnet ef migrations add InitialCreate --project /Infrasturcture project/ --startup-project /WebApp project/"
5. Run "Update-Database"

### Connect to database
1. Open Sql Server Management Studio
2. On the "Connect to Server" select the following options:
  - Server type: Database Engine 
  - Server name: localhost\sqlexpress
  - Authentication: "Windows Authentication"
