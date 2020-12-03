#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 

#WORKDIR /app

#COPY ./WebApplication/bin/Release/netcoreapp3.1/ .

#EXPOSE 5000

#ENTRYPOINT ["dotnet", "WebApplication.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY . .
EXPOSE 4020
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication.dll