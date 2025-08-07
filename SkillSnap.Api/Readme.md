

## Database Migrations


### Revert to InitalCreate
dotnet ef migrations list
dotnet ef database update InitialCreate
dotnet ef migrations remove


### Apply all migrations
dotnet ef migrations add "InitialCreate" -o "Data/Migrations"
dotnet ef database update

dotnet ef migrations add "add Application User" -o "Data/Migrations"
dotnet ef database update
