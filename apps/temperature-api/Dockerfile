# ---------- STAGE 1: Build ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish --no-restore

# ---------- STAGE 2: Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8081
ENV ASPNETCORE_URLS=http://0.0.0.0:8081

ENTRYPOINT ["dotnet", "temperature-api.dll"]