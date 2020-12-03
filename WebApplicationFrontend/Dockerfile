FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.5 


WORKDIR /app

COPY ./WebbApplicationFrontend/bin/Release/netcoreapp3.1/ .

EXPOSE 4020

USER node

ENTRYPOINT ["dotnet", "WebbApplicationFrontend.dll"]