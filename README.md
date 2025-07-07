# Ticket Status API

API that returns the status description of a ticket, using data from a local SQL Server database.

This project is built with ASP.NET Core and Entity Framework.

## How to run

1. Make sure SQL Server is installed and the 'Fusion_Master' database is restored locally.
2. Check that your connection string in 'appsettings.json' points to your local SQL Server instance.
3.  Open the solution in Visual Studio and click the green **Run** button
4.  A browser window should open at 'http://localhost:5109'
5.  Swagger will load so that the API endpoint can be tested


## Example
GET request to:

    /api/Ticket/199407

Response:

```json
{
  "ticketID": 199407,
  "status": "In Progress"
}
