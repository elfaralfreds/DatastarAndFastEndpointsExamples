# Use the official .NET 9 SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Install Node.js 22.x
RUN apt-get update \
    && apt-get install -y curl gnupg \
    && curl -fsSL https://deb.nodesource.com/setup_22.x | bash - \
    && apt-get install -y nodejs \
    && rm -rf /var/lib/apt/lists/*

# Set the working directory
WORKDIR /src

# Copy the project file and restore dependencies
COPY FastDatastar/*.csproj ./FastDatastar/
COPY FastDatastar.sln ./FastDatastar.sln
RUN dotnet restore .

# Copy the rest of the application code
COPY . .

# Build the application
WORKDIR /src/FastDatastar

RUN npm install
RUN npm run build:css
RUN dotnet publish FastDatastar.csproj -c Release -o /app/publish

# Use the official .NET 9 runtime image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Expose the port the application runs on
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Set the entry point for the application
ENTRYPOINT ["dotnet", "FastDatastar.dll"]