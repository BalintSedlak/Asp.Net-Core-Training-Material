#Build Stage
FROM mcr.microsoft.com/mssql/server:2022-latest

ENV ACCEPT_EULA=Y
ENV MSSQL_TCP_PORT=1433

WORKDIR /scripts

COPY ./SQL .

#RUN sleep 5s
#RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Docker1234' -i CreateDatabase.sql
#RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Docker1234' -d NorthwindDocker -i CreateTables.sql
#RUN /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Docker1234' -d NorthwindDocker -i SeedData_Up.sql
#RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" && sleep 30s && /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'Docker1234' -i Northwind.sql
