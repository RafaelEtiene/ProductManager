# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia o arquivo da solution e o projeto
COPY ProductManager.sln ./
COPY ProductManager.csproj ./

# Restaura as dependências
RUN dotnet restore ProductManager.csproj

# Copia o restante dos arquivos
COPY . ./

# Publica a aplicação
RUN dotnet publish ProductManager.csproj -c Release -o /out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia o build
COPY --from=build /out ./

# Expõe a porta
EXPOSE 8080

# Comando de execução
ENTRYPOINT ["dotnet", "ProductManager.dll"]
