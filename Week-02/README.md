# Week 2

## Day 1 – Generics & Advanced Collections

### Topics Covered

- Why Generics
- Generic Classes
- Generic Constraints
- Collection Interfaces

### Hands-on Lab

Implemented a generic repository.

#### Features

- Created a generic `Repository<T>` class.
- Applied the `where T : class` generic constraint.
- Added an `Add(T item)` method.
- Added a `GetAll()` method that returns `IReadOnlyList<T>`.
- Added a `Find(Func<T, bool> predicate)` method.
- Tested the repository with two Week 1 domain models (`User` and `Admin`).
- Added a comment explaining why the generic constraint is used.

---

## Day 2 – Advanced LINQ & Deferred Execution

### Topics Covered

- Deferred vs. Immediate Execution
- GroupBy
- Join
- SelectMany
- LINQ Performance Concepts

### Hands-on Lab

Implemented advanced LINQ queries using related collections.

#### Features

- Created `Customer` and `Order` classes.
- Created two related collections with six records each.
- Used `GroupBy` to calculate the total order amount for each customer.
- Used `Join` to combine customer names with their order amounts.
- Used `SelectMany` to flatten nested collections into a single sequence.
- Demonstrated Deferred Execution by modifying the source collection before query execution.

---

## Day 3 – Async/Await Deep Dive & Concurrency Basics

### Topics Covered

- Task-based Asynchronous Programming
- Async / Await
- Sequential Execution
- Concurrent Execution with `Task.WhenAll`
- Cancellation Tokens

### Hands-on Lab

Implemented asynchronous operations and compared sequential and concurrent execution.

#### Features

- Created three asynchronous methods to simulate different data sources.
- Used `Task.Delay()` to simulate long-running operations.
- Executed async methods sequentially using `await`.
- Measured execution time using `Stopwatch`.
- Executed multiple tasks concurrently using `Task.WhenAll()`.
- Compared sequential and concurrent execution times.
- Implemented cancellation using `CancellationToken`.
- Handled `OperationCanceledException`.

---

## Day 4 – ASP.NET Core Web API

### Topics Covered

- ASP.NET Core Web API
- API Controllers
- Routing
- HTTP GET Requests
- IActionResult
- Ok() and NotFound()
- Swagger
- Postman
- Minimal APIs

### Hands-on Lab

Built RESTful APIs using Controllers and Minimal APIs.

#### Features

- Created an `ItemsController`.
- Implemented:
  - `GET /api/items`
  - `GET /api/items/{id}`
- Returned **404 Not Found** for invalid IDs.
- Created Minimal API endpoints:
  - `GET /minimal/items`
  - `GET /minimal/items/{id}`
- Tested all endpoints using Swagger and Postman.
- Verified successful (`200 OK`) and failed (`404 Not Found`) responses.
- Learned the difference between Controller-based APIs and Minimal APIs.
- Returned JSON responses from API endpoints.

---

## Day 5 – Middleware & Dependency Injection

### Topics Covered

- ASP.NET Core Middleware
- Middleware Pipeline
- Custom Middleware
- Dependency Injection (DI)
- Service Lifetimes
- Constructor Injection

### Hands-on Lab

Implemented custom middleware and Dependency Injection in an ASP.NET Core Web API.

#### Features

- Created `RequestLoggingMiddleware`.
- Logged every incoming HTTP request.
- Registered middleware in `Program.cs`.
- Tested incorrect middleware ordering and restored the correct order.
- Created `IMessageService` and `MessageService`.
- Registered the service using `AddSingleton()`.
- Injected the service into `ItemsController` using constructor injection.
- Added the endpoint:
  - `GET /api/items/message`
- Returned:

```text
Hello from Dependency Injection!
```

---

## Technologies Used

- C#
- .NET 8
- ASP.NET Core Web API
- Swagger
- Postman
- Visual Studio Code
- Git
- GitHub

---

## Progress

✅ Day 1 Completed

✅ Day 2 Completed

✅ Day 3 Completed

✅ Day 4 Completed

✅ Day 5 Completed

---

# Week 2 Summary

After completing the second week of the BinX Backend Internship, I expanded my backend development skills by learning advanced C# concepts and building RESTful APIs with ASP.NET Core.

Throughout this week, I implemented generic repositories, explored advanced LINQ operations, practiced asynchronous programming and concurrency, and built Web APIs using both Controllers and Minimal APIs. I also tested APIs using Swagger and Postman, created custom middleware, and implemented Dependency Injection to build more modular and maintainable applications.

The biggest lesson I learned is that backend development is not only about creating API endpoints, but also about designing scalable, reusable, and maintainable applications by applying modern ASP.NET Core architecture and best practices.

This week strengthened my understanding of ASP.NET Core and prepared me to continue building more advanced backend applications in the upcoming weeks.
