FROM node:14.15.0-alpine as build-stage
WORKDIR /usr/app
COPY package*.json ./
RUN npm install --silent
COPY . .
RUN npm run build

FROM nginx:1.19.1-alpine
COPY --from=build-stage /usr/app/dist /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
