#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 3004

ENV ASPNETCORE_URLS=http://*:3004


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["APIgateway.Ocelot/APIgateway.Ocelot.csproj", "APIgateway.Ocelot/"]
RUN dotnet restore "APIgateway.Ocelot/APIgateway.Ocelot.csproj"
COPY . .
WORKDIR "/src/APIgateway.Ocelot"
RUN dotnet build "APIgateway.Ocelot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIgateway.Ocelot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIgateway.Ocelot.dll"]