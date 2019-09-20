FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CustomerData.Api/CustomerData.Api.csproj", "CustomerData.Api/"]
RUN dotnet restore "CustomerData.Api/CustomerData.Api.csproj"
COPY . .
WORKDIR "/src/CustomerData.Api"
RUN dotnet build "CustomerData.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CustomerData.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CustomerData.Api.dll"]