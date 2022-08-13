##  How to add new migration
1.  dotnet ef migrations add MigrationName
2.  run dotnet ef database update
3.  heroku run dotnet ef database update -a mh-idle

