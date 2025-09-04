# Use a imagem base do SDK .NET 8 para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar arquivos de projeto e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar todo o código fonte e compilar
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use a imagem runtime para produção
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /app/publish .

# Expor a porta 80
EXPOSE 80
EXPOSE 443

# Definir o ponto de entrada
ENTRYPOINT ["dotnet", "ArtoniumApi.dll"]
