FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy everything
EXPOSE 8080
EXPOSE 5223
# Restore as distinct layers
COPY *.csproj ./
RUN dotnet restore
# Build and publish a release
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Nuevo.dll"]