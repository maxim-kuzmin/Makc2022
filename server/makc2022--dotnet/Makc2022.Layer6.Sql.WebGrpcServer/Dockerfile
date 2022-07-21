#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Makc2022.Layer6.Sql.WebGrpcServer/Makc2022.Layer6.Sql.WebGrpcServer.csproj", "Makc2022.Layer6.Sql.WebGrpcServer/"]
RUN dotnet restore "Makc2022.Layer6.Sql.WebGrpcServer/Makc2022.Layer6.Sql.WebGrpcServer.csproj"
COPY . .
WORKDIR "/src/Makc2022.Layer6.Sql.WebGrpcServer"
RUN dotnet build "Makc2022.Layer6.Sql.WebGrpcServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Makc2022.Layer6.Sql.WebGrpcServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Makc2022.Layer6.Sql.WebGrpcServer.dll"]