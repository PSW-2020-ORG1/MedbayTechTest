FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY ./WebApplication/bin/Release/netcoreapp3.1/ .

#EXPOSE 5000
EXPOSE 4200
ENTRYPOINT ["dotnet", "WebApplication.dll"]