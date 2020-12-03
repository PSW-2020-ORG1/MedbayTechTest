FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 

WORKDIR /app

COPY ./PharmacyIntegration/bin/Release/netcoreapp3.1/ .

EXPOSE 8081
USER node

ENTRYPOINT ["dotnet", "PharmacyIntegration.dll"]