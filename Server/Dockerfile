FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY ./ ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build vue app
FROM node AS node-builder
WORKDIR /node
COPY ./client /node
RUN npm install
RUN npm run build

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/bin/Release/net6.0/publish .
COPY --from=node-builder /node/dist ./client/dist
ENV ASPNETCORE_URLS=http://+:$PORT
ENTRYPOINT ["dotnet", "Server.dll", "--urls", "http://*:$PORT"]
