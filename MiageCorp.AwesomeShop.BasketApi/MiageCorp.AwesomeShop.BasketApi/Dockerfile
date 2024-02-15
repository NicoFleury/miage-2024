#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MiageCorp.AwesomeShop.BasketApi/MiageCorp.AwesomeShop.BasketApi.csproj", "MiageCorp.AwesomeShop.BasketApi/"]
RUN dotnet restore "MiageCorp.AwesomeShop.BasketApi/MiageCorp.AwesomeShop.BasketApi.csproj"
COPY . .
WORKDIR "/src/MiageCorp.AwesomeShop.BasketApi"
RUN dotnet build "MiageCorp.AwesomeShop.BasketApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiageCorp.AwesomeShop.BasketApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiageCorp.AwesomeShop.BasketApi.dll"]