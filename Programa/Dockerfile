FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /App
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["PersonasConsoleRegister.csproj", "./"]
RUN dotnet restore "PersonasConsoleRegister.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PersonasConsoleRegister.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonasConsoleRegister.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonasConsoleRegister.dll"]