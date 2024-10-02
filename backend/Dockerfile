FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build-env

WORKDIR /app

COPY ["JobGuard.Api/JobGuard.Api.csproj", "JobGuard.Api/"]
RUN dotnet restore "JobGuard.Api/JobGuard.Api.csproj"

COPY . .
RUN dotnet build "JobGuard.Api/JobGuard.Api.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "JobGuard.Api/JobGuard.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobGuard.Api.dll"]
