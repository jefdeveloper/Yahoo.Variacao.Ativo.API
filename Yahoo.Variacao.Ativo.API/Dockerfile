#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Yahoo.Variacao.Ativo.API/Yahoo.Variacao.Ativo.API.csproj", "Yahoo.Variacao.Ativo.API/"]
RUN dotnet restore "Yahoo.Variacao.Ativo.API/Yahoo.Variacao.Ativo.API.csproj"
COPY . .
WORKDIR "/src/Yahoo.Variacao.Ativo.API"
RUN dotnet build "Yahoo.Variacao.Ativo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yahoo.Variacao.Ativo.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yahoo.Variacao.Ativo.API.dll"]

RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh