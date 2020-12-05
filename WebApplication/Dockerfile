FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

COPY ./Backend/bin/Release/netcoreapp3.1/ .
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.0 && \
 dotnet-ef migrations script -p "Backend.dll" -o /app/sql/init.sql


FROM base AS final
WORKDIR /app

COPY ./WebApplication/bin/Release/netcoreapp3.1/ .

WORKDIR /WebApplication/bin/Release/netcoreapp3.1
VOLUME /app/sql
EXPOSE 80
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication.dll

#ENTRYPOINT ["dotnet", "WebApplication.dll"]