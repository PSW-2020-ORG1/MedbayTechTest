<<<<<<< HEAD
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build

#WORKDIR /app

#COPY ./Backend/bin/Release/netcoreapp3.1/ .
#ENV PATH $PATH:/root/.dotnet/tools
#RUN dotnet tool install -g dotnet-ef --version 3.1.0 && \
# dotnet-ef migrations script -p "Backend.dll" -o /app/sql/init.sql


#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

#FROM base AS final
#WORKDIR /app

#COPY ./WebApplication/bin/Release/netcoreapp3.1/ .

#WORKDIR /WebApplication/bin/Release/netcoreapp3.1
#VOLUME /app/sql
#EXPOSE 80
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication.dll

#ENTRYPOINT ["dotnet", "WebApplication.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
 
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY . .
RUN dotnet restore "WebApplication/WebApplication.csproj" && \
    dotnet build "WebApplication/WebApplication.csproj" -c Release -o /app/build

 
FROM build AS publish
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.0 && \
    dotnet publish "WebApplication/WebApplication.csproj" -c Release -o /app/publish && \
    dotnet-ef migrations script -p "WebApplication/WebApplication.csproj" -o /app/sql/init.sql

 
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/publish
VOLUME /app/sql
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApplication.dll