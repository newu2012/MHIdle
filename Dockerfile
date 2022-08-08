FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY *.sln ./
COPY ./EntityModels.Postgresql/*.csproj ./EntityModels.Postgresql/
COPY ./DataContext.Postgresql/*.csproj ./DataContext.Postgresql/
COPY ./Server/*.csproj ./Server/

# Restore as distinct layers
RUN dotnet restore

COPY EntityModels.Postgresql/. ./EntityModels.Postgresql/
COPY DataContext.Postgresql/. ./DataContext.Postgresql/
COPY Server/. ./Server/

# Build and publish a release
WORKDIR /app
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
COPY --from=build-env /app/out ./
COPY --from=node-builder /node/dist ./dist

# Copy .env file with configs
COPY ./Server/production.env ./

ENV ASPNETCORE_URLS=http://+:$PORT
ENTRYPOINT ["dotnet", "Server.dll", "--urls", "http://*:$PORT"]
