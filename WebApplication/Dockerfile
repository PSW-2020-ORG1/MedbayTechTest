FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY ./WebApplication/bin/Release/netcoreapp3.1/ .

RUN dotnet tool install -g dotnet-ef --version 3.1.0
RUN dotnet ef migrations add Init

ENTRYPOINT ["dotnet", "WebApplication.dll"]