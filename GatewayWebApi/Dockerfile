#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["GatewayWebApi/GatewayWebApi.csproj", "GatewayWebApi/"]
RUN dotnet restore "GatewayWebApi/GatewayWebApi.csproj"
COPY . .
WORKDIR "/src/GatewayWebApi"
RUN dotnet build "GatewayWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GatewayWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GatewayWebApi.dll"]