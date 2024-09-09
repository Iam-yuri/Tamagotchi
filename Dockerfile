# Use a imagem base do .NET SDK para construir o projeto
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Defina o diretório de trabalho
WORKDIR /app

# Copie o arquivo de projeto e restaure as dependências
COPY TamagotchiPokemon.csproj ./
RUN dotnet restore

# Copie o restante do código e construa o projeto
COPY . ./
RUN dotnet publish -c Release -o out

# Use a imagem base do .NET Runtime para executar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Defina o diretório de trabalho
WORKDIR /app

# Copie os arquivos de build para a imagem final
COPY --from=build /app/out .

# Exponha a porta que o aplicativo vai escutar
EXPOSE 80

# Defina o comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "TamagotchiPokemon.dll"]

