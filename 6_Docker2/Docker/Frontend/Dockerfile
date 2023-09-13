#Dev config
FROM node:current-alpine AS development
ENV NODE_ENV development
WORKDIR /app
# Copy package.json and package-lock.json to the container
COPY ./frontend/package*.json ./
#Install dependencies
RUN npm install
# Copy the rest of the application code to the container
COPY ./frontend .
EXPOSE 3000
# Start the React app
CMD ["npm", "start"]

#This image is used to create Production build
FROM node:current-alpine AS builder
ENV NODE_ENV production
WORKDIR /app
# Cache and Install dependencies
COPY ./frontend/package*.json .
RUN npm install --omit=dev
# Copy app files
COPY ./frontend .
# Build the app
RUN npm run build

# Production host
FROM nginx:stable-alpine as production
ENV NODE_ENV production
# Copy built assets from builder
COPY --from=builder /app/build /usr/share/nginx/html
# Add your nginx.conf
COPY ./frontend/nginx.conf /etc/nginx/conf.d/default.conf
# Expose port
EXPOSE 80
# Start nginx
CMD ["nginx", "-g", "daemon off;"]

