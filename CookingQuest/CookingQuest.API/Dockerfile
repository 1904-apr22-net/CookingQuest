FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CookingQuest.API/CookingQuest.API.csproj", "CookingQuest.API/"]
COPY ["CookingQuest.Data/CookingQuest.Data.csproj", "CookingQuest.Data/"]
COPY ["CookingQuest.Library/CookingQuest.Library.csproj", "CookingQuest.Library/"]
RUN dotnet restore "CookingQuest.API/CookingQuest.API.csproj"
COPY . .
WORKDIR "/src/CookingQuest.API"
RUN dotnet build "CookingQuest.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CookingQuest.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CookingQuest.API.dll"]