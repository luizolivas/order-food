# Usa a imagem leve do Node.js baseada no Alpine Linux
FROM node:alpine

# Define o diretório de trabalho dentro do contêiner
WORKDIR /usr/app

# Copia apenas os arquivos necessários para instalar dependências
COPY package.json package-lock.json ./

# Instala as dependências do projeto
RUN npm install

# Agora copia todo o código para dentro do contêiner
COPY . .

# Instala o Angular CLI globalmente
RUN npm install -g @angular/cli

# Expõe a porta padrão do Angular
EXPOSE 4200

# Comando padrão para rodar a aplicação
CMD ["ng", "serve", "--host", "0.0.0.0"]
