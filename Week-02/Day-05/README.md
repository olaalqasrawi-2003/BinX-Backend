# Day 05 – Middleware & Dependency Injection

## Overview
On Day 05, I learned how the ASP.NET Core request pipeline works by creating custom middleware and implementing Dependency Injection (DI). I also explored service lifetimes and constructor injection to build more maintainable and scalable applications.

---

## Topics Covered

- ASP.NET Core Middleware
- Middleware Pipeline
- Custom Middleware
- Dependency Injection (DI)
- Service Lifetimes
- Constructor Injection

---

## Tasks Completed

### 1. Custom Middleware

- Created a custom middleware class named `RequestLoggingMiddleware`.
- Logged every incoming HTTP request to the console.
- Displayed both the request method and request path.

Example:

```text
Request: GET /api/items
Request: GET /minimal/items
```

---

### 2. Middleware Pipeline

- Registered the middleware inside `Program.cs`.
- Tested incorrect middleware ordering.
- Observed how placing middleware after `app.Run()` prevents it from executing.
- Restored the correct middleware order.

---

### 3. Dependency Injection

Created:

- `IMessageService`
- `MessageService`

Registered the service using:

```csharp
builder.Services.AddSingleton<IMessageService, MessageService>();
```

---

### 4. Constructor Injection

Injected `IMessageService` into `ItemsController` using constructor injection.

Example:

```csharp
public ItemsController(IMessageService messageService)
{
    _messageService = messageService;
}
```

---

### 5. API Endpoint

Added a new endpoint:

```text
GET /api/items/message
```

Response:

```text
Hello from Dependency Injection!
```

---

## Technologies Used

- C#
- .NET 8
- ASP.NET Core Web API
- Swagger
- Visual Studio Code
- Git & GitHub

---

## Learning Outcome

By the end of Day 05, I was able to:

- Understand the ASP.NET Core request pipeline.
- Build custom middleware.
- Register services using Dependency Injection.
- Apply constructor injection.
- Understand service lifetimes.
- Test API endpoints using Swagger.
