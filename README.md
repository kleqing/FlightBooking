# FlightBooking

A small website allow user buy flight ticket using ASP .NET with API

## Environment

- PostgreSQL
- Rider 2024.3
- VSCode
- DbSchema (SQL Management)

## How to install

- Run this command in Terminal:
    ```
    dotnet ef database update --project Models --startup-project FlightBooking --context DbContext
    ```

**NOTE:** If the `Model` has an update, please run the command above again, or you can follow these step:
```
dotnet ef migrations remove --project Models --startup-project FlightBooking --context DbContext
```
```
dotnet ef migrations add "Initial" --project Models --startup-project FlightBooking --context DbContext
```
```
dotnet ef database update --project Models --startup-project FlightBooking --context DbContext
```

***IMPORTANT:*** **REMEMBER TO CHANGE THE CONNECTION STRING PASSWORD IN `FlightBooking/appsettings.json`**