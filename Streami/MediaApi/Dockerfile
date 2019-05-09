FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["MediaApi/MediaApi.csproj", "MediaApi/"]
RUN dotnet restore "MediaApi/MediaApi.csproj"
COPY . .
WORKDIR "/src/MediaApi"
RUN dotnet build "MediaApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MediaApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MediaApi.dll"]
