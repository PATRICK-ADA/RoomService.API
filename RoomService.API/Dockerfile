#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy and restore each project
COPY ["RoomService.API/RoomService.API.csproj", "RoomService.API/"]
COPY ["RoomService.Core/RoomService.Core.csproj", "RoomService.Core/"]
COPY ["RoomService.Domain/RoomService.Domain.csproj", "RoomService.Domain/"]
COPY ["RoomService.Infrastructure/RoomService.Infrastructure.csproj", "RoomService.Infrastructure/"]
RUN dotnet restore "./RoomService.API/RoomService.API.csproj"

# Copy all files
COPY . .

# Set the working directory to the API project folder
WORKDIR "/src/RoomService.API"

# Build the project
RUN dotnet build "./RoomService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RoomService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomService.API.dll"]
