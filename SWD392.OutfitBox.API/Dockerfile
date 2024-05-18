#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 424
EXPOSE 425
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SWD392.OutfitBox.API/SWD392.OutfitBox.API.csproj", "SWD392.OutfitBox.API/"]
COPY ["SWD392.OutfitBox.Core/SWD392.OutfitBox.Core.csproj", "SWD392.OutfitBox.Core/"]
COPY ["SWD392.OutfitBox.Domain/SWD392.OutfitBox.Domain.csproj", "SWD392.OutfitBox.Domain/"]
COPY ["SWD392.OutfitBox.Infrastructure/SWD392.OutfitBox.Infrastructure.csproj", "SWD392.OutfitBox.Infrastructure/"]
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