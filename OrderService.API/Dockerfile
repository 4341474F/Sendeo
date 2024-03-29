#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS="https://*:5001" 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OrderService.API/OrderService.API.csproj", "OrderService.API/"]
COPY ["OrderService/OrderService.csproj", "OrderService/"]
COPY ["ProdcutAPI/ProductAPI.csproj", "ProdcutAPI/"]
RUN dotnet restore "OrderService.API/OrderService.API.csproj"
COPY . .
WORKDIR "/src/OrderService.API"
RUN dotnet build "OrderService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderService.API.dll"]