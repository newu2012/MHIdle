##  How to add new migration
1. dotnet ef migrations add MigrationName
2. dotnet ef database update

##  If you need to update production db
1. copy database url from production.env to development.env
2. dotnet ef database update
3. put back development url 
