# ===== Stage 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем решение и проекты
COPY PulseHub.sln ./
COPY Shared/Shared.csproj ./Shared/
COPY AuthService/AuthService.csproj ./AuthService/
COPY CatalogService/CatalogService.csproj ./CatalogService/
COPY OrderService/OrderService.csproj ./OrderService/
COPY Tests/Tests.csproj ./Tests/

# Восстанавливаем зависимости
RUN dotnet restore PulseHub.sln

# Копируем исходники и публикуем
COPY . .
RUN dotnet publish AuthService -c Release -o /app/publish

# ===== Stage 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "AuthService.dll"]
