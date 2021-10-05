#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 3002

ENV ASPNETCORE_URLS=http://*:3002

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MicroServices.Coffee/MicroServices.Coffee.csproj", "MicroServices.Coffee/"]
RUN dotnet restore "MicroServices.Coffee/MicroServices.Coffee.csproj"
COPY . .
WORKDIR "/src/MicroServices.Coffee"
RUN dotnet build "MicroServices.Coffee.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroServices.Coffee.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroServices.Coffee.dll"]