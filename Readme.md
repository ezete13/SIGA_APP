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
