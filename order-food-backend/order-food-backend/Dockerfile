# Usa a imagem oficial do .NET SDK para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /App

# Copia todos os arquivos do projeto
COPY . ./
# Restaura dependências
RUN dotnet restore
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
