FROM mcr.microsoft.com/dotnet/framework/sdk:3.5

WORKDIR C:/work/src
COPY app.cs .
RUN "C:\Windows\Microsoft.NET\Framework64\v2.0.50727\csc.exe" app.cs

CMD ["app.exe"]
