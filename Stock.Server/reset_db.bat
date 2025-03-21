@cls

rd /s /q Migrations

dotnet ef database drop --force

sqllocaldb stop

dotnet ef migrations add Initial

dotnet ef database update