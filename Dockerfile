FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env

WORKDIR /src
COPY ./DOTNET_5_EF_PostgreSQL_Docker/DOTNET_5_EF_PostgreSQL_Docker.csproj DOTNET_5_EF_PostgreSQL_Docker/

RUN dotnet restore DOTNET_5_EF_PostgreSQL_Docker/DOTNET_5_EF_PostgreSQL_Docker.csproj

COPY ./DOTNET_5_EF_PostgreSQL_Docker DOTNET_5_EF_PostgreSQL_Docker/

RUN dotnet build DOTNET_5_EF_PostgreSQL_Docker/DOTNET_5_EF_PostgreSQL_Docker.csproj -c Debug -o /app/build
RUN dotnet publish DOTNET_5_EF_PostgreSQL_Docker/DOTNET_5_EF_PostgreSQL_Docker.csproj -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
EXPOSE 443
EXPOSE 80
WORKDIR /app
COPY --from=build-env /app/publish .

COPY ./DOTNET_5_EF_PostgreSQL_Docker/aspnetapp.pfx /https/
# RUN update-ca-certificates

ENTRYPOINT ["dotnet", "DOTNET_5_EF_PostgreSQL_Docker.dll"]
