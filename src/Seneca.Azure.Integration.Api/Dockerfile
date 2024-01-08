FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Seneca.Azure.Integration.Api/Seneca.Azure.Integration.Api.csproj", "Seneca.Azure.Integration.Api/"]
RUN dotnet restore "Seneca.Azure.Integration.Api/Seneca.Azure.Integration.Api.csproj"
COPY . .
WORKDIR "/src/Seneca.Azure.Integration.Api"
RUN dotnet build "Seneca.Azure.Integration.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Seneca.Azure.Integration.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Seneca.Azure.Integration.Api.dll"]
