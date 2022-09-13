# FROM mcr.microsoft.com/mssql/server:2017-latest as sqlserver

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY . .
RUN dotnet nuget add source http://10.200.8.182:8081/repository/nuget.minedu/
RUN dotnet restore
WORKDIR /src
RUN dotnet build  -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SISPUN.INVENT.API/SISPUN.INVENT.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
RUN  ls /app
COPY --from=publish /app/publish .
ENTRYPOINT ["sh", "-c", "dotnet SISPUN.INVENT.API.dll"] 

# TO BUILD: 
#    docker build -t minedu/sispun_msa_inventario:latest .

# TO RUN 
#    docker run -it --rm -d -p 15001:80 -p 15002:443  minedu/sispun_msa_inventario:latest