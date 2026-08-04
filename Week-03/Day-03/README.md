# Day 03 – Entity Framework Core Setup & Code-First Migrations

## Overview

On Day 03, I learned how to integrate Entity Framework Core with SQL Server using the Code-First approach. I created entity classes, configured a DbContext, connected the application to SQL Server, and generated the database through EF Core migrations.

---

## Learning Objectives

- Install and configure Entity Framework Core.
- Connect a .NET application to SQL Server.
- Create entity classes.
- Create and configure a DbContext.
- Configure the connection string using `appsettings.json`.
- Register the DbContext in `Program.cs`.
- Generate Code-First migrations.
- Create the database from C# models.
- Verify the created tables in SQL Server Management Studio (SSMS).

---

## What I Implemented

### 1. Installed Required Packages

Installed the required NuGet packages for Entity Framework Core and SQL Server.

- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.Extensions.Configuration
- Microsoft.Extensions.Configuration.Json
- Microsoft.Extensions.Configuration.FileExtensions

---

### 2. Created Entity Classes

Created the following entity models:

- Author
- Book
- Category
- Member
- Loan

---

### 3. Created AppDbContext

Implemented `AppDbContext` by inheriting from `DbContext` and exposed a `DbSet` for each entity.

---

### 4. Configured SQL Server

- Created `appsettings.json`
- Added the SQL Server connection string.
- Registered `AppDbContext` inside `Program.cs`.

---

### 5. Created the First Migration

Generated the initial migration using:

```bash
dotnet ef migrations add InitialCreate
```

---

### 6. Updated the Database

Applied the migration using:

```bash
dotnet ef database update
```

---

### 7. Verified the Database

Opened SQL Server Management Studio (SSMS) and verified that the following tables were successfully created:

- Authors
- Books
- Categories
- Members
- Loans
- __EFMigrationsHistory

---

## Technologies Used

- C#
- .NET
- Entity Framework Core
- SQL Server
- SQL Server Management Studio (SSMS)

---

## Skills Practiced

- Entity Framework Core
- SQL Server Integration
- DbContext Configuration
- Code-First Development
- Database Migrations
- Dependency Injection
- Configuration Management

---

## Result

Successfully connected a .NET application to SQL Server using Entity Framework Core, generated the first migration, created the database, and verified all tables in SQL Server Management Studio.

---
