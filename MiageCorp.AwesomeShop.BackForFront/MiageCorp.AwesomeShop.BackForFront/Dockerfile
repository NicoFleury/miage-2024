#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MiageCorp.AwesomeShop.BackForFront/MiageCorp.AwesomeShop.BackForFront.csproj", "MiageCorp.AwesomeShop.BackForFront/"]
RUN dotnet restore "MiageCorp.AwesomeShop.BackForFront/MiageCorp.AwesomeShop.BackForFront.csproj"
COPY . .
WORKDIR "/src/MiageCorp.AwesomeShop.BackForFront"
RUN dotnet build "MiageCorp.AwesomeShop.BackForFront.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiageCorp.AwesomeShop.BackForFront.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiageCorp.AwesomeShop.BackForFront.dll"]