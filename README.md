# stock
Angular .NET Project

Run the Client App with `play_client.bat`:

```
cd stock.client & ng serve -o
```

Run the Server App with `play_server.bat`:

```
dotnet run --project Stock.Server\Stock.Api --launch-profile Https | start chrome https://localhost:7292/swagger
```
