# Week 03 - Day 04: Building a CRUD API with Entity Framework Core

## Overview
On Day 04, I learned how to build a complete CRUD Web API using ASP.NET Core and Entity Framework Core. The API was connected to a SQL Server database, allowing data to be stored, retrieved, updated, and deleted. I also learned how Entity Framework Core manages database operations through DbContext and asynchronous programming.

---

## Learning Objectives
- Understand Entity Framework Core fundamentals.
- Configure a SQL Server database connection.
- Create and use DbContext.
- Perform CRUD operations with Entity Framework Core.
- Use asynchronous database methods.
- Handle validation and error responses.
- Test API endpoints using Swagger and Postman.

---

## Topics Covered
- Entity Framework Core
- SQL Server Integration
- DbContext Configuration
- Dependency Injection
- CRUD Operations
- Asynchronous Programming (async/await)
- SaveChangesAsync()
- HTTP Status Codes
- Model Validation
- API Testing with Swagger
- API Testing with Postman

---

## Features Implemented

### Database Configuration
- Configured SQL Server connection.
- Registered AppDbContext using Dependency Injection.
- Applied Entity Framework Core migrations.
- Updated the database successfully.

### CRUD Endpoints
- Get all books
- Get book by ID
- Create a new book
- Update an existing book
- Delete a book

### Validation & Error Handling
- Return **200 OK** for successful requests.
- Return **201 Created** when creating a new book.
- Return **204 No Content** after successful deletion.
- Return **400 Bad Request** for invalid input.
- Return **404 Not Found** when a book does not exist.

### Testing
- Tested all endpoints using Swagger.
- Tested all endpoints using Postman.
- Verified success and error scenarios for each endpoint.

---

## Technologies Used
- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server Express
- Swagger
- Postman

---

## What I Learned
- How Entity Framework Core communicates with SQL Server.
- How to configure and inject DbContext.
- How to build a database-driven REST API.
- How to perform asynchronous CRUD operations.
- How SaveChangesAsync() persists changes to the database.
- How to return appropriate HTTP status codes.
- How to test REST APIs using Swagger and Postman.
- How to troubleshoot database connection and migration issues.

---

## Project Status
✅ SQL Server Connected

✅ Entity Framework Core Configured

✅ Database Created

✅ CRUD Operations Completed

✅ Swagger Testing Completed

✅ Postman Testing Completed

✅ Build Successful