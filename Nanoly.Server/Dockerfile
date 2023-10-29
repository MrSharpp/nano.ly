FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet build -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "api.dll" ]