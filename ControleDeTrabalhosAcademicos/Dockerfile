# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["ControleDeTrabalhosAcademicos.csproj", "./"]
RUN dotnet restore "ControleDeTrabalhosAcademicos.csproj"

# Copy everything else and build the app
COPY . .
RUN dotnet build "ControleDeTrabalhosAcademicos.csproj" -c Release -o /app/build

# Publish the app to the /app/publish directory
FROM build AS publish
RUN dotnet publish "ControleDeTrabalhosAcademicos.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Run the application
ENTRYPOINT ["dotnet", "ControleDeTrabalhosAcademicos.dll"]
