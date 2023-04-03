#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Repeater_bot/Repeater_bot.csproj", "Repeater_bot/"]
RUN dotnet restore "Repeater_bot/Repeater_bot.csproj"
COPY . .
WORKDIR "/src/Repeater_bot"
RUN dotnet build "Repeater_bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Repeater_bot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Repeater_bot.dll"]