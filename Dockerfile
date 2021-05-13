FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /app

COPY *.sln .
COPY WebApplication/*.csproj ./WebApplication/
COPY WebApplication.Migrator/*.csproj ./WebApplication.Migrator/
COPY WebApplication.Infrastructure/*.csproj ./WebApplication.Infrastructure/

RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=build /app/out/ .

ENV ASPNETCORE_ENVIRONMENT=Production

CMD ["dotnet", "WebApplication.dll"]
