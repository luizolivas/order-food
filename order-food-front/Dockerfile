FROM node:alpine

WORKDIR /usr/src/app/



# Copia apenas os arquivos necessários para instalar dependênciass
COPY package*.json ./

RUN npm install

# Agora copia todo o código para dentro do contêiner
COPY . .

# Instala o Angular CLI globalmente
RUN npm install -g @angular/cli

CMD ["ng", "serve", "--host", "0.0.0.0"]
