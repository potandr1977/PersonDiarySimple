#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["PersonDiary.Person.WebApi/PersonDiary.Person.WebApi.csproj", "PersonDiary.Person.WebApi/"]
COPY ["PersonDiary.Person.Domain/PersonDiary.Person.Domain.csproj", "PersonDiary.Person.Domain/"]
COPY ["PersonDiary.Person.Dto/PersonDiary.Person.Dto.csproj", "PersonDiary.Person.Dto/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Dto/PersonDiary.Infrastructure.Dto.csproj", "Infrastructure/PersonDiary.Infrastructure.Dto/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Domain/PersonDiary.Infrastructure.Domain.csproj", "Infrastructure/PersonDiary.Infrastructure.Domain/"]
COPY ["PersonDiary.Person.DataAccess.PostgreSQL/PersonDiary.Person.DataAccess.PostgreSQL.csproj", "PersonDiary.Person.DataAccess.PostgreSQL/"]
COPY ["PersonDiary.Person.Business/PersonDiary.Person.Business.csproj", "PersonDiary.Person.Business/"]
COPY ["PersonDiary.Person.ApiClient/PersonDiary.Person.ApiClient.csproj", "PersonDiary.Person.ApiClient/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.EventBus.RabbitMq/PersonDiary.Infrastructure.EventBus.RabbitMq.csproj", "Infrastructure/PersonDiary.Infrastructure.EventBus.RabbitMq/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.ApiClient/PersonDiary.Infrastructure.ApiClient.csproj", "Infrastructure/PersonDiary.Infrastructure.ApiClient/"]
RUN dotnet restore "PersonDiary.Person.WebApi/PersonDiary.Person.WebApi.csproj"
COPY . .
WORKDIR "/src/PersonDiary.Person.WebApi"
RUN dotnet build "PersonDiary.Person.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonDiary.Person.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonDiary.Person.WebApi.dll"]