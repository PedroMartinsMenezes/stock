@cls

rmdir /s /q Migrations

dotnet ef database drop --force --project ..\Stock.Repository --startup-project ..\Stock.Api

sqllocaldb stop

dotnet ef migrations add Initial --project ..\Stock.Repository --startup-project ..\Stock.Api

dotnet ef database update --project ..\Stock.Repository --startup-project ..\Stock.Api

pause