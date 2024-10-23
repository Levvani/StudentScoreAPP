# Step 1: Base image
# Use the official ASP.NET runtime image for .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80  # Expose port 80 for the API

# Step 2: Build image
# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything to the working directory
COPY . .

# Restore the .NET packages
RUN dotnet restore "TVStoreAPP.csproj"

# Build the project in Release mode
RUN dotnet build "TVStoreAPP.csproj" -c Release -o /app/build

# Step 3: Publish image
FROM build AS publish
RUN dotnet publish "TVStoreAPP.csproj" -c Release -o /app/publish

# Step 4: Final image
FROM base AS final
WORKDIR /app

# Copy the published files to the working directory
COPY --from=publish /app/publish .

# Set the entry point to run your API
ENTRYPOINT ["dotnet", "YourProjectName.dll"]
