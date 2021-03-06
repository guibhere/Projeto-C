FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
    
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MeuApp/Projeto-C-.csproj", "MeuApp/"]
RUN dotnet restore "MeuApp/Projeto-C-.csproj"
COPY ./MeuApp ./MeuApp
WORKDIR "/src/MeuApp"
RUN dotnet build "Projeto-C-.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Projeto-C-.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN useradd -m myappuser
USER myappuser

ENTRYPOINT ["dotnet","Projeto-C-.dll"]