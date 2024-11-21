# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . . 
RUN dotnet restore
RUN dotnet build --configuration Release

# Publish the app
RUN dotnet publish --configuration Release --output /out

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /out .

# Expose the port
EXPOSE 5210

# Command to run the application
ENTRYPOINT ["dotnet", "PRO05_backend_riley_tanya_dani_levi.dll"]
