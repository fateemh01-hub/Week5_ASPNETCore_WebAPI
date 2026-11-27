# Week 5 - ASP.NET Core Web API

## Project Overview
An ASP.NET Core Web API developed using .NET 10.

## Technologies
- ASP.NET Core Web API
- ASP.NET Core Identity
- JWT Authentication
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## Features
- User registration and login.
- JWT-based authentication.
- Protected API endpoints.
- Products CRUD operations.
- Entity Framework Core migrations.
- Swagger API documentation.

## Local Testing
The following operations were tested locally:
- User registration and login.
- JWT authorization.
- Get all products.
- Create a product.
- Update a product.
- Delete a product.
- Unauthorized access returns HTTP 401.

## Database
The project uses SQL Server and Entity Framework Core migrations.

## Configuration
Connection strings and JWT signing keys must be configured using User Secrets or environment variables.

Never commit passwords, database credentials, or JWT signing keys.

## Deployment Status
The remote database schema was created successfully.
The API application deployment and hosted database connection are still pending.

## Running Locally
1. Restore NuGet packages.
2. Configure the database connection and JWT key.
3. Apply Entity Framework migrations.
4. Run the application.
5. Open Swagger at:

http://localhost:5062/swagger
