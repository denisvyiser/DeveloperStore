#Imagem de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

#Imagem para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

#Nome do projeto
ARG COMPOSE_PROJECT_NAME
ARG PROJECTNAME

#Define o diretório de trabalho
WORKDIR "/${COMPOSE_PROJECT_NAME}"

#Copia tudo para pasta do workdir, faz o restore e copia os pacotes
COPY . .
RUN dotnet restore "${COMPOSE_PROJECT_NAME}.sln" --configfile NuGet.Config
COPY . .

#Define o diretório de trabalho sobre o projeto de API
WORKDIR "/${COMPOSE_PROJECT_NAME}/src/DevStore.${PROJECTNAME}.Api"

RUN dotnet build "${PROJECTNAME}.Api.csproj" -c Release -o /app

#Pela imagem de build, gera o deploy
FROM build AS publish
RUN dotnet publish "DevStore.${PROJECTNAME}.Api.csproj" -c Release -o /app

#Copia o deploy para imagem base
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DevStore.${PROJECTNAME}.Api.dll"]