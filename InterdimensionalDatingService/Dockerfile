FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["InterdimensionalDatingService/InterdimensionalDatingService.csproj", "InterdimensionalDatingService/"]
RUN dotnet restore "InterdimensionalDatingService/InterdimensionalDatingService.csproj"
COPY . .
WORKDIR "/src/InterdimensionalDatingService"
RUN dotnet build "InterdimensionalDatingService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterdimensionalDatingService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterdimensionalDatingService.dll"]
