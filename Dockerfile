FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8888

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PowerPlant.API/PowerPlant.API.csproj", "PowerPlant.API/"]
RUN dotnet restore "PowerPlant.API/PowerPlant.API.csproj"
COPY . .
WORKDIR "/src/PowerPlant.API"
RUN dotnet build "PowerPlant.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PowerPlant.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8888
ENTRYPOINT ["dotnet", "PowerPlant.API.dll","--server.urls","http://localhost:8888;https://localhost:8888"]
