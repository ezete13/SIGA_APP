# SIGA: Sistema Integral de Gestion Académica

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
