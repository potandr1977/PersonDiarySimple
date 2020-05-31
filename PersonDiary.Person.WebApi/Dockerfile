#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["PersonDiary.Person.WebApi/PersonDiary.Person.WebApi.csproj", "PersonDiary.Person.WebApi/"]
COPY ["PersonDiary.Person.Domain/PersonDiary.Person.Domain.csproj", "PersonDiary.Person.Domain/"]
COPY ["PersonDiary.Person.Dto/PersonDiary.Person.Dto.csproj", "PersonDiary.Person.Dto/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Dto/PersonDiary.Infrastructure.Dto.csproj", "Infrastructure/PersonDiary.Infrastructure.Dto/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.Domain/PersonDiary.Infrastructure.Domain.csproj", "Infrastructure/PersonDiary.Infrastructure.Domain/"]
COPY ["PersonDiary.Person.Business/PersonDiary.Person.Business.csproj", "PersonDiary.Person.Business/"]
COPY ["PersonDiary.Person.ApiClient/PersonDiary.Person.ApiClient.csproj", "PersonDiary.Person.ApiClient/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.EventBus.RabbitMq/PersonDiary.Infrastructure.EventBus.RabbitMq.csproj", "Infrastructure/PersonDiary.Infrastructure.EventBus.RabbitMq/"]
COPY ["Infrastructure/PersonDiary.Infrastructure.ApiClient/PersonDiary.Infrastructure.ApiClient.csproj", "Infrastructure/PersonDiary.Infrastructure.ApiClient/"]
COPY ["PersonDiary.Person.DataAccess.Ef/PersonDiary.Person.DataAccess.Ef.csproj", "PersonDiary.Person.DataAccess.Ef/"]
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