FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/KeyVaultEmulator/KeyVaultEmulator.csproj", "src/KeyVaultEmulator/"]
RUN dotnet restore "src/KeyVaultEmulator/KeyVaultEmulator.csproj"
COPY . .
WORKDIR "/src/src/KeyVaultEmulator"
RUN dotnet build "KeyVaultEmulator.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "KeyVaultEmulator.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
VOLUME /key-vault
ENTRYPOINT ["dotnet", "KeyVaultEmulator.dll"]