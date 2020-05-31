#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["PersonDiary.LifeEvent.WebApi/PersonDiary.LifeEvent.WebApi.csproj", "PersonDiary.LifeEvent.WebApi/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.EventBus.RabbitMq/PersonDiary.Infrastructure.EventBus.RabbitMq.csproj", "Infrastructure/PersonDiary.Infrastructure.EventBus.RabbitMq/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Domain/PersonDiary.Infrastructure.Domain.csproj", "Infrastructure/PersonDiary.Infrastructure.Domain/"]
COPY ["PersonDiary.LifeEvent.Domain/PersonDiary.LifeEvent.Domain.csproj", "PersonDiary.LifeEvent.Domain/"]
COPY ["PersonDiary.LifeEvent.Dto/PersonDiary.LifeEvent.Dto.csproj", "PersonDiary.LifeEvent.Dto/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Dto/PersonDiary.Infrastructure.Dto.csproj", "Infrastructure/PersonDiary.Infrastructure.Dto/"]
COPY ["PersonDiary.Lifeevent.Cache/PersonDiary.Lifeevent.Cache.csproj", "PersonDiary.Lifeevent.Cache/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Cache/PersonDiary.Infrastructure.Cache.csproj", "Infrastructure/PersonDiary.Infrastructure.Cache/"]
COPY ["PersonDiary.LifeEvent.DataAccess.Ef/PersonDiary.LifeEvent.DataAccess.Ef.csproj", "PersonDiary.LifeEvent.DataAccess.Ef/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.ApiClient/PersonDiary.Infrastructure.ApiClient.csproj", "Infrastructure/PersonDiary.Infrastructure.ApiClient/"]
COPY ["PersonDiary.LifeEvent.Business/PersonDiary.LifeEvent.Business.csproj", "PersonDiary.LifeEvent.Business/"]
COPY ["PersonDiary.Lifeevent.ApiClient/PersonDiary.Lifeevent.ApiClient.csproj", "PersonDiary.Lifeevent.ApiClient/"]
RUN dotnet restore "PersonDiary.LifeEvent.WebApi/PersonDiary.LifeEvent.WebApi.csproj"
COPY . .
WORKDIR "/src/PersonDiary.LifeEvent.WebApi"
RUN dotnet build "PersonDiary.LifeEvent.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonDiary.LifeEvent.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonDiary.LifeEvent.WebApi.dll"]