# Logistics BackOffice GraphQL API 

The repository contains a backend of Logistics BackOffice project for Logistics and field service management. The backend serves as a GraphQL server. Application has docker container orchestration configured.

## Database Schema

![database schema](https://storageinstanceaccount.blob.core.windows.net/receivingphotos/EntitiesModel.png?sv=2021-10-04&spr=https%2Chttp&st=2023-08-06T23%3A17%3A51Z&se=2023-08-07T23%3A17%3A51Z&sr=b&sp=r&sig=Ey5wai%2FlnyaGVGkVn7UnGobytvhHEQkA756u7tOAaoY%3D&rsct=image%2Fpng)

What's included:

- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Hot Chocolate](https://chillicream.com/docs/hotchocolate)
- [MediatR]
- [EF Core](https://docs.microsoft.com/en-us/ef/core/)
- [Azure SQL]
- [Docker] 

### Docker Configuration

In order to get Docker working, you will need to add a temporary SSL cert and mount a volume to hold that cert. You can find [Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/security/docker-https?view=aspnetcore-6.0) that describe the steps required for Windows, macOS, and Linux.

The following will need to be executed from your terminal to create a cert.

For Windows:

```bash
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p 1qaz2wsx@
dotnet dev-certs https --trust
```

FOR macOS:

```bash
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p 1qaz2wsx@
dotnet dev-certs https --trust
```

FOR Linux:

```bash
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p 1qaz2wsx@
```

In order to build and run the docker containers locally, execute below command from the root of the solution.

```bash
docker-compose -f 'docker-compose.yml' up --build
```

### Database Configuration

You will need to update `src/GraphQL/appsettings.json` as follows:

```json
{
  "ConnectionStrings": {
    "SqlDbConnection": "Server=azure;Initial Catalog=LogisticsBackOffice;Persist Security Info=False;User ID=sa;Password=****;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  },
  "UseInMemoryDatabase": "false"
}
```

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied. The sample test data in `NDC_London_2019.json` will be imported automatically.

### Database Migrations

To use `dotnet-ef` for your migrations run below commands from the root of the project.

Run Migrations:

```bash
dotnet ef migrations add InitialMigration --project src/Infrastructure --startup-project src/GraphQL --output-dir Persistence/Migrations
```

Update database:

```bash
dotnet ef database update --project src/Infrastructure --startup-project src/GraphQL
```

### Build and run from source

With Visual studio:
Open up the solutions using Visual studio.

- Restore solution `nuget` packages.
- Rebuild solution once.
- Run the solution.
- Banana cake pop local URL [here](https://localhost:5001/graphql).
- Voyager local URL [here](https://localhost:5001/graphql-voyager)