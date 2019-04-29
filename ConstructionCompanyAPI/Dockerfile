FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["ConstructionCompanyAPI/ConstructionCompanyAPI.csproj", "ConstructionCompanyAPI/"]
RUN dotnet restore "ConstructionCompanyAPI/ConstructionCompanyAPI.csproj"
COPY . .
WORKDIR "/src/ConstructionCompanyAPI"
RUN dotnet build "ConstructionCompanyAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ConstructionCompanyAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ConstructionCompanyAPI.dll"]