FROM  mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src

COPY Nanoly.Server/api.csproj Nanoly.Server/
RUN dotnet restore "Nanoly.Server/api.csproj"

COPY . .
RUN ls

WORKDIR "/src/Nanoly.Server"
RUN dotnet build "api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "api.csproj" -c Release -o /app/publish


FROM node:18 as build-react
WORKDIR /app/client
COPY Nanoly.Client/package*.json ./
RUN npm install
COPY Nanoly.Client/ ./
RUN npm run build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build-react /app/client/dist ./wwwroot

RUN ls

ENTRYPOINT [ "dotnet", "api.dll" ]
