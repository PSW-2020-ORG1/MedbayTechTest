FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY MQuince.WebAPI/MQuince.WebAPI.csproj MQuince.WebAPI/
COPY MQuince.Services.Contracts/MQuince.Services.Contracts.csproj MQuince.Services.Contracts/
COPY MQuince.Entities/MQuince.Entities.csproj MQuince.Entities/
COPY MQuince.Enums/MQuince.Enums.csproj MQuince.Enums/
COPY MQuince.Application/MQuince.Application.csproj MQuince.Application/
COPY MQuince.Repository.Contracts/MQuince.Repository.Contracts.csproj MQuince.Repository.Contracts/
COPY MQuince.Services.Implementation/MQuince.Services.Implementation.csproj MQuince.Services.Implementation/
COPY MQuince.Repository.SQL/MQuince.Repository.SQL.csproj MQuince.Repository.SQL/
COPY MQuince.Services.Tests/MQuince.Services.Tests.csproj MQuince.Services.Tests/

RUN dotnet restore MQuince.WebAPI/MQuince.WebAPI.csproj

COPY . .

FROM build AS test
LABEL test=true
RUN dotnet test -c Release --results-directory /testresults --logger "trx;LogFileName=test_results.trx" MQuince.Services.Tests/MQuince.Services.Tests.csproj

FROM build AS publish
WORKDIR /app/MQuince.Repository.SQL
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install -g dotnet-ef --version 3.1.0
RUN dotnet ef migrations add Init
WORKDIR /app
COPY MQuince.WebAPI/clientapp out/clientapp
RUN dotnet publish MQuince.WebAPI/MQuince.WebAPI.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
RUN useradd -ms /bin/bash defaultuser
WORKDIR /app
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000
EXPOSE 80
COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "MQuince.WebAPI.dll"]