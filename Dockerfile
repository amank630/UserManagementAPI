# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 10000

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["User_Management_API.csproj", "."]
RUN dotnet restore "./User_Management_API.csproj"

COPY . .
RUN dotnet publish "./User_Management_API.csproj" -c Release -o /app/publish

# Final stage
FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "User_Management_API.dll"]