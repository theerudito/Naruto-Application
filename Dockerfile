# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar los archivos de la solución y restaurar las dependencias
COPY ./*.sln ./
COPY ./Naruto.Backend/*.csproj ./Naruto.Backend/
COPY ./Naruto.Data/*.csproj ./Naruto.Data/
COPY ./Naruto.Helpers/*.csproj ./Naruto.Helpers/
COPY ./Naruto.Models/*.csproj ./Naruto.Models/
COPY ./Naruto.Service/*.csproj ./Naruto.Service/


# Restaurar las dependencias
RUN dotnet restore

# Copiar todo el código fuente y compilar la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de tiempo de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 80

# Define el comando de inicio para ejecutar la aplicación
ENTRYPOINT ["dotnet", "Naruto.Backend.dll"] 