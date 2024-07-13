FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SWD392.OutfitBox.API/SWD392.OutfitBox.API.csproj", "SWD392.OutfitBox.API/"]
COPY ["SWD392.OutfitBox.BackgroundWorker/SWD392.OutfitBox.BackgroundWorker.csproj", "SWD392.OutfitBox.BackgroundWorker/"]
COPY ["SWD392.OutfitBox.BusinessLayer/SWD392.OutfitBox.BusinessLayer.csproj", "SWD392.OutfitBox.BusinessLayer/"]
COPY ["SWD392.OutfitBox.DataLayer/SWD392.OutfitBox.DataLayer.csproj", "SWD392.OutfitBox.DataLayer/"]
RUN dotnet restore "SWD392.OutfitBox.API/SWD392.OutfitBox.API.csproj"
COPY . .
WORKDIR "/src/SWD392.OutfitBox.API"
RUN dotnet build "SWD392.OutfitBox.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SWD392.OutfitBox.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SWD392.OutfitBox.API.dll"]