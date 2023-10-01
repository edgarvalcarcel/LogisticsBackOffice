FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ENV ASPNETCORE_URLS=https://+:4001;http://+:4000
WORKDIR /app
EXPOSE 4000
EXPOSE 4001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/GraphQL/GraphQL.csproj", "src/GraphQL/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
RUN dotnet restore "src/GraphQL/GraphQL.csproj"
COPY . .
WORKDIR "/src/src/GraphQL"
RUN dotnet build "GraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogisticsBackOffice.dll"]
