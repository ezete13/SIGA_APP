# SIGA: Sistema Integral de Gestion Académica

# 1 - Inicializar imagen de DockerCompose.

docker-compose up -d


# 2 - Instalar las herramietnas de dotnet ef

dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef


# 3 - Crear la migración 

dotnet ef migrations add InitialCreate --output-dir Migrations

# 4 - Verificar que se creó la migración 

- Lista las migraciones existentes
dotnet ef migrations list


# 5 - Aplicar la migración a la base de datos 

dotnet ef database update

- Si es necesario especificar a cadena de conexión 

dotnet ef database update --connection "Host=localhost;Database=SIGA_DB;Username=postgres;Password=tu_password"






## Comandos Utiles 
### Docker
Al levantarlo se cargan las tablas y los seeds automáticamente.

- docker-compose up -d
- docker-compose down -v
- docker logs db-siga

## User Secrets
Dentro del proeycto en donde se use, hacer un set con el connection string de la bd

- cd src/SIGA.WebApi
- dotnet user-secrets init
- dotnet user-secrets set
- dotnet user-secrets list

## EntityFramework
dotnet ef dbcontext scaffold
dotnet ef database update
dotnet ef migrations add


git config --global user.name "ezete13"
git config --global user.email "telloezequiel8@gmail.com"



EF_DB_SCAFFOLD = "Host=127.0.0.1;Database=db_siga;Username=developer;Password=3z3Qu!3l_1994" Npgsql.EntityFrameworkCore.PostgreSQL -o ../SIGA.Domain/Entities --context-dir . --context ApplicationDbContext --no-pluralize --force --namespace SIGA.Domain.Entities --context-namespace SIGA.Persistence



SECRET_CONNECTION_STRING = "ConnectionStrings:DefaultConnection" "Host=127.0.0.1;Port=5432;Database=db_siga;Username=developer;Password=3z3Qu!3l_1994"


# Migración 

Perfecto, para **Visual Studio Code** usando la terminal integrada, sigue estos pasos:

## Paso 1: Abrir la terminal en VS Code
- `Ctrl + ñ` o `View → Terminal`
- Asegúrate de estar en el directorio del proyecto que contiene el DbContext (SIGA.Persistence)

## Paso 2: Verificar que estás en el proyecto correcto
```bash
# Verifica que estás en la carpeta correcta
pwd
# Debería mostrar algo como: /ruta/a/SIGA.Persistence
```

## Paso 3: Instalar herramienta dotnet ef (si no la tienes)
```bash
dotnet tool install --global dotnet-ef
```

O actualizarla si ya la tienes:
```bash
dotnet tool update --global dotnet-ef
```

## Paso 4: Crear la migración inicial
```bash
dotnet ef migrations add InitialCreate --output-dir Migrations
```

Si quieres un nombre más descriptivo:
```bash
dotnet ef migrations add InitialSchema --output-dir Migrations

```

## Paso 5: Verificar que se creó la migración
```bash
# Lista las migraciones existentes
dotnet ef migrations list
```

## Paso 6: Aplicar la migración a la base de datos
```bash
dotnet ef database update
```

Si necesitas especificar la cadena de conexión manualmente:
```bash
dotnet ef database update --connection "Host=localhost;Database=SIGA_DB;Username=postgres;Password=tu_password"
```

## Comandos útiles adicionales en terminal

### Ver migraciones pendientes
```bash
dotnet ef migrations list
```

### Revertir a una migración específica
```bash
dotnet ef database update NombreMigracionAnterior
```

### Eliminar la última migración (si no se aplicó)
```bash
dotnet ef migrations remove
```

### Generar script SQL
```bash
dotnet ef migrations script -o script.sql
```

### Ver el contexto y las entidades
```bash
dotnet ef dbcontext info
```

## Paso 7: Verificar en PostgreSQL

Conéctate a PostgreSQL para verificar:
```bash
# Si tienes psql instalado
psql -U postgres -d SIGA_DB -c "\dt siga.*"
```

O usa un cliente como pgAdmin, DBeaver, etc.

## Solución de problemas comunes en VS Code

### Error: "No se encontró ninguna instalación de dotnet-ef"
```bash
dotnet tool install --global dotnet-ef
# Cierra y vuelve a abrir la terminal
```

### Error: "No se pudo encontrar el proyecto"
Asegúrate de estar en la carpeta correcta:
```bash
cd src/SIGA.Persistence  # o la ruta donde está tu proyecto
```

### Error de cadena de conexión
Si no tienes configurada la cadena en appsettings.json, puedes pasarla directamente:
```bash
dotnet ef database update --connection "Host=localhost;Database=SIGA_DB;Username=postgres;Password=123456"
```

### Error de permisos en PostgreSQL
```bash
# Conéctate a PostgreSQL y crea la base de datos si no existe
psql -U postgres
CREATE DATABASE SIGA_DB;
\q
```

## Resumen de comandos en orden

```bash
# 1. Ir al proyecto correcto
cd SIGA.Persistence

# 2. Instalar/actualizar dotnet-ef (si es necesario)
dotnet tool install --global dotnet-ef

# 3. Crear migración
dotnet ef migrations add InitialCreate --output-dir Migrations

# 4. Aplicar migración
dotnet ef database update

# 5. Verificar
dotnet ef migrations list
```

¡Y eso es todo! La migración debería crear todas las tablas en PostgreSQL con el esquema `siga`.