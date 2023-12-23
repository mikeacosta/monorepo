FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HoopsPlayersAPI/HoopsPlayersAPI.csproj", "HoopsPlayersAPI/"]
RUN dotnet restore "HoopsPlayersAPI/HoopsPlayersAPI.csproj"
COPY . .
WORKDIR "/src/HoopsPlayersAPI"
RUN dotnet build "HoopsPlayersAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "HoopsPlayersAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HoopsPlayersAPI.dll"]

#ENV ConnectionStrings__DefaultConnectionString="Host=postgres-db;Database=dev_db;Username=postgres;Password=Abc12345"