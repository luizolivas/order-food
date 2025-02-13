# Usando a imagem do .NET SDK para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiando e restaurando dependências
COPY . .
RUN dotnet restore

# Compilando o código
RUN dotnet publish -c Release -o /out

# Usando a imagem do runtime para rodar o backend
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

# Comando para rodar a aplicação
CMD ["dotnet", "OrderFoodBackend.dll"]
