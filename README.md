# DAB_2_Solution_grp6

---
> It is recommended to run Microsoft SQL Server with Docker, to do this you can [follow this guide](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&preserve-view=true&pivots=cs1-powershell). You don't have to run the database in Docker, but it's <b>important</b> to use Microsoft SQL Server as this application uses the NuGet-package [Microsoft.EntityFrameworkCore.SqlServer](https://learn.microsoft.com/en-us/ef/core/providers/sql-server/?tabs=dotnet-core-cli).
## Quick Guide

1. Connect to your SQL Server.
2. Get the `ConnectionString` of your database.
3. In the VS-solution navigate to `appsettings.json`.
4. Replace the current `ConnectionString` with your personal `ConnectionString`.
5. In Visual Studio go to <b>Tools</b> -> <b>NuGet Package Manager</b> -> <b>Package Manager Console.</b>
6. The PMC terminal will open.
7. Type the following: `Update-Database`.
8. Refresh your database.
9.  You should now see that tables have been added.
10. You can now start the solution (Press <kbd>F5</kbd>).
11. If the database does not contain any data, the program will Seed some dummy-data automatically the first time you launch the program. Otherwise you can use the "Reset" endpoints in the SwaggerUI
12. Try out the different queries in the SwaggerUI.

### Please note that the solution is the final solution of assignment 2, meaning that you will not be able to see JIT-Meals anymore, but you will instead be able to see staff-information (query 7).
## Step 3:
> `appsettings.json` looks something like this, insert your personal connectionstring as shown.
```Json 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
    
  },
  "AllowedHosts": "*",
    "ConnectionStrings": {
      "Database": "INSERT_YOUR_CONNECTIONSTRING_HERE"
    }
}
```
If your `ConnectionString` does not contain the following settings: `Encrypt=False;Trust Server Certificate=False;` then please add them. A full `ConnectionString` would look something like this: `"Data Source=localhost;User ID=<SOME_USERID>;Password=<SOME_PASSWORD>;Initial Catalog=<YOUR_CHOSEN_DATABASE_NAME>;Encrypt=False;Trust Server Certificate=False;"`