# Usa a imagem oficial do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Define a pasta de trabalho
WORKDIR /App

# Copia apenas o arquivo de projeto primeiro
COPY order-food-backend/order-food-backend/order-food-backend.csproj ./

# Restaura dependências antes de copiar o restante do código
RUN dotnet restore

# Copia o restante do código
COPY order-food-backend/order-food-backend/. ./

# Compila e publica o projeto
RUN dotnet publish -c Release -o /App/out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /App

# Copia os arquivos publicados para o diretório de execução
COPY --from=build /App/out ./

# Debug: Verifica os arquivos copiados
RUN ls -la /App

# Comando para rodar o backend
CMD ["dotnet", "order-food-backend.dll"]
