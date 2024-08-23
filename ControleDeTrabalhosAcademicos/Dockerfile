# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura dependências
COPY *.csproj ./
RUN dotnet restore "ControleDeTrabalhosAcademicos.csproj"

# Copia o restante do código
COPY . .

# Realiza o build especificando o arquivo de projeto
RUN dotnet build "ControleDeTrabalhosAcademicos.csproj" -c Release -o /app/build

# Etapa de publicação
FROM build AS publish
RUN dotnet publish "ControleDeTrabalhosAcademicos.csproj" -c Release -o /app/publish

# Etapa final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Exponha a porta usada pela aplicação
EXPOSE 80

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "ControleDeTrabalhosAcademicos.dll"]
