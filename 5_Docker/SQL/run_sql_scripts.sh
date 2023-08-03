#!/bin/bash

# Function to execute sqlcmd command
execute_sqlcmd() {
    /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Docker1234' -d NorthwindDocker -i "$1"
}

execute_sqlcmd "CreateDatabase.sql"
execute_sqlcmd "CreateTables.sql"
execute_sqlcmd "SeedCustomers.sql"
execute_sqlcmd "SeedRegion.sql"
execute_sqlcmd "SeedTerritories.sql"
execute_sqlcmd "SeedEmployees.sql"
execute_sqlcmd "SeedEmployeeTerritories.sql"