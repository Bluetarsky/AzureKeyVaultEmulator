FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/KeyVaultEmulator/AzureKeyVaultEmulator.csproj", "src/KeyVaultEmulator/"]
RUN dotnet restore "src/KeyVaultEmulator/AzureKeyVaultEmulator.csproj"
COPY . .
WORKDIR "/src/src/KeyVaultEmulator"
RUN dotnet build "AzureKeyVaultEmulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzureKeyVaultEmulator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME /key-vault
HEALTHCHECK --interval=5s --timeout=10s --retries=3 CMD curl --fail http://localhost:80/health || exit 1
ENTRYPOINT ["dotnet", "AzureKeyVaultEmulator.dll"]