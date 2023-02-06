FROM mcr.microsoft.com/dotnet/framework/runtime:3.5

WORKDIR C:/work/mssql2014
COPY SQLEXPR_x64_ENU.exe .
RUN SQLEXPR_x64_ENU.exe /q /X:C:\work\mssql2014\setup

# Install
WORKDIR C:/work/mssql2014/setup
RUN .\setup.exe \
    /q \
    /ACTION=Install \
    /INSTANCENAME=SQLEXPRESS \
    /FEATURES=SQLEngine \
    /UPDATEENABLED=1 \
    /SECURITYMODE=SQL \
    /SAPWD="P@ssw0rd" \
    /SQLSVCACCOUNT="NT AUTHORITY\System" \
    /AGTSVCACCOUNT="NT AUTHORITY\Network Service" \
    /SQLSYSADMINACCOUNTS="BUILTIN\ADMINISTRATORS" \
    /INSTALLSQLDATADIR=C:\SQLEXPRESS\DATA \
    /SQLUSERDBLOGDIR=C:\SQLEXPRESS\DATA \
    /SQLBACKUPDIR=C:\SQLEXPRESS\BACKUP \
    /TCPENABLED=1 \
    /NPENABLED=0 \
    /IACCEPTSQLSERVERLICENSETERMS

# Setup
RUN powershell Set-ItemProperty \
    -Path 'HKLM:\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQLServer\SuperSocketNetLib\Tcp\ipall' \
    -Name TcpDynamicPorts \
    -Value ''
RUN powershell Set-ItemProperty \
    -Path 'HKLM:\SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQLServer\SuperSocketNetLib\Tcp\ipall' \
    -Name TcpPort \
    -Value 1433

# Run
RUN net start "MSSQL$SQLEXPRESS"

# Initialize
WORKDIR C:/work/mssql2014
COPY create.sql .
COPY insert.sql .
RUN sqlcmd -U sa -P P@ssw0rd -Q "create database sample;"
RUN sqlcmd -U sa -P P@ssw0rd -d sample -i create.sql
RUN sqlcmd -U sa -P P@ssw0rd -d sample -i insert.sql

CMD ["cmd"]
