FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build-env

WORKDIR /app

COPY ["src/JobGuard.Api/JobGuard.Api.csproj", "src/JobGuard.Api/"]
RUN dotnet restore "src/JobGuard.Api/JobGuard.Api.csproj"

COPY . .
RUN dotnet build "src/JobGuard.Api/JobGuard.Api.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "src/JobGuard.Api/JobGuard.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy-chiseled AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobGuard.Api.dll"]
