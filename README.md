
  

✨ **This workspace has been generated by ASP.NET Core Web API  ( .NET 6) ✨


## Creating or Updating the Database
**IMPORTANT**
Go To file `users_api\Sources\DBData.cs`
and config the variables `dbUser` and  `dbPassword` to generate the sql serve connection

Use the following command to create or update the database schema

In **Package Manager Console**
run `Update-Database`  

You must create a database with migration called
**DoubleVPartnersDb**

**And 2 tables**
1.  People
2. Users

**2 Stored Procedures**
1. get_people
2. get_users


## Run this workspace
init program and go to
`https://localhost:7059/`  

## User by default
user:admin
password:admin
