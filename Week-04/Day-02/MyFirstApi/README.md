# Week 04 - Day 01: ASP.NET Core Identity & User Registration

## What I Learned

- ASP.NET Core Identity basics
- Setting up Identity with Entity Framework Core
- Creating Identity tables using migrations
- Implementing a user registration endpoint
- Password validation using ASP.NET Core Identity
- Testing user registration using Postman

## What I Did

- Added ASP.NET Core Identity to the existing API project.
- Updated `AppDbContext` to use `IdentityDbContext<IdentityUser>`.
- Registered Identity services in `Program.cs`.
- Created a new migration for Identity.
- Updated the database with the Identity tables.
- Created `AuthController`.
- Added a registration endpoint using `UserManager<IdentityUser>`.
- Tested registration requests using Postman.

## Identity Migration

Created the Identity migration:

```bash
dotnet ef migrations add AddIdentity
```

Then updated the database:

```bash
dotnet ef database update
```

The migration added the ASP.NET Core Identity tables to the database.

## Registration Endpoint

Created a registration endpoint:

```text
POST /api/Auth/register
```

The endpoint accepts an email and password and uses ASP.NET Core Identity to create the user.

## Postman Testing

I tested the registration endpoint using Postman.

### Weak Password Test

A password that did not meet the Identity password requirements returned:

```text
400 Bad Request
```

Identity returned a validation error because the password did not contain an uppercase letter.

### Successful Registration

After using a password that met the requirements, the request returned:

```text
200 OK
User registered successfully
```

## Tools Used

- ASP.NET Core Identity
- Entity Framework Core
- Postman