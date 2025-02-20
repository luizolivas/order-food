FROM node:20.15.1-alpine

WORKDIR /usr/src/app

# Copia apenas package.json e package-lock.json primeiro (para otimizar cache)
COPY package*.json ./

# Instala as dependências antes de copiar o restante dos arquivos
RUN npm install

# Agora copia todo o código para dentro do contêiner
COPY . .

# Instala o Angular CLI globalmente
RUN npm install -g @angular/cli

CMD ["ng", "serve", "--host", "0.0.0.0"]
