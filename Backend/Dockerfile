FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY ./Backend/bin/Release/netcoreapp3.1/ .

EXPOSE 5000

ENTRYPOINT ["dotnet", "Backend.dll"]
