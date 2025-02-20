FROM node:alpine

WORKDIR /usr/app
COPY ./ /usr/app
RUN npm install

# Agora copia todo o código para dentro do contêiner
COPY . .

# Instala o Angular CLI globalmente
RUN npm install -g @angular/cli

CMD ["ng", "serve", "--host", "0.0.0.0"]
