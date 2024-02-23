FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Werewolf.Bot/Werewolf.Bot.csproj", "Werewolf.Bot/"]
RUN dotnet restore "Werewolf.Bot/Werewolf.Bot.csproj"
COPY . .
WORKDIR "/src/Werewolf.Bot"
RUN dotnet build "Werewolf.Bot.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Werewolf.Bot.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Werewolf.Bot.dll"]
