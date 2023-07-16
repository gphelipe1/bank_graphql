# Bank Func_Graphql
A C# API with .NET Core that simulates some functionalities of a digital bank using GraphQL (HotChocolate).

## [Database]
The database uses MySQL, simply add the appropriate connection string in the appsettings file..

- Default Connection String:
> "AppDbConnectionString": "server=localhost;database=LifeCare;User=root;Password=root;"

### [Docker] - How to Run MySql in a Docker Container
This repository contains a docker-compose file. To run the database you can run the following steps:
- Go to  **https://www.docker.com/** and get the latest version of docker
- Define your ROOT password in the docker-compose file (MYSQL_ROOT_PASSWORD) and the database name (MYSQL_DATABASE)
- In the root of the project, simply use the command.
```sh
docker-compose up -d
```

## [Backend - C#, .NET 7 | GraphQL /HotChocolate.AspNetCore]
 This repository contains a usefull usage of HotChocolate to set an API using GraphQL

## [Backend]
- To run the backend of the aplication, simply run the commands below.
We are using Entity Framework, so first you need to update the database using the command: 
```sh
dotnet ef update database
``` 
Than you can execute:
```sh
dotnet build
dotnet run
```
The backend was built using .NET Core version 7

## [Unit Testing]
For unit testing, we used Xunit. You can find the tests in the "Tests" folder. To run them, simply open the terminal at the project's root and execute the following command:
```sh
dotnet test --logger "console;verbosity=detailed"
```
## [Calling the API - Samples]
The execution of this project cover the following samples:
- The repo automatically creates a sample object in the database, an account with the account number 54321 and a balance of 160, but you can also create new accounts or even delete them. Accounts are created with a default balance of 0.

**Sample 1**

Request:

```
mutation {
  sacar(conta: 54321, valor: 140) {
    conta
    saldo
  }
}
```

Response:

```
{
  "data": {
    "sacar": {
      "conta": 54321,
      "saldo": 20
    }
  }
}
```

**Sample 2**

Request

```
mutation {
  sacar(conta: 54321, valor: 30000) {
    conta
    saldo
  }
}
```

Response

```
{
  "errors": [
    {
      "message": "Saldo insuficiente.",
      "locations": [
        {
          "line": 2,
          "column": 3
        }
      ],
      "path": [
        "sacar"
      ]
    }
  ]
}
```

**Sample 3**

Request:

```
mutation {
  depositar(conta: 54321, valor: 200) {
    conta
    saldo
  }
}
```

Response:

```
{
  "data": {
    "depositar": {
      "conta": 54321,
      "saldo": 220
    }
  }
}
```

**Sample 4**

Request:

```
query {
  saldo(conta: 54321)
}
```

Response:

```
{
  "data": {
    "saldo": 220
  }
}
```
