#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 3003

ENV ASPNETCORE_URLS=http://*:3003

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MicroServices.Tea/MicroServices.Tea.csproj", "MicroServices.Tea/"]
RUN dotnet restore "MicroServices.Tea/MicroServices.Tea.csproj"
COPY . .
WORKDIR "/src/MicroServices.Tea"
RUN dotnet build "MicroServices.Tea.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroServices.Tea.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServices.Tea.dll"]