#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["GatewayWebApi/PersonDiary.Gateway.WebApi.csproj", "GatewayWebApi/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.ApiClient/PersonDiary.Infrastructure.ApiClient.csproj", "Infrastructure/PersonDiary.Infrastructure.ApiClient/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Domain/PersonDiary.Infrastructure.Domain.csproj", "Infrastructure/PersonDiary.Infrastructure.Domain/"]
COPY ["PersonDiary.GateWay.ApiClient/PersonDiary.GateWay.ApiClient.csproj", "PersonDiary.GateWay.ApiClient/"]
COPY ["PersonDiary.GateWay.Dto/PersonDiary.GateWay.Dto.csproj", "PersonDiary.GateWay.Dto/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Dto/PersonDiary.Infrastructure.Dto.csproj", "Infrastructure/PersonDiary.Infrastructure.Dto/"]
RUN dotnet restore "GatewayWebApi/PersonDiary.Gateway.WebApi.csproj"
COPY . .
WORKDIR "/src/GatewayWebApi"
RUN dotnet build "PersonDiary.Gateway.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonDiary.Gateway.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonDiary.Gateway.WebApi.dll"]