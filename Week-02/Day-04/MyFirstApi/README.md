# Week 02 - Day 04
# ASP.NET Core Web API - Controllers & Minimal APIs

## Overview
In this task, I learned how to build REST APIs using ASP.NET Core. I created API Controllers, tested endpoints with Swagger and Postman, and implemented both Controller-based APIs and Minimal APIs.

---

## Topics Covered
- ASP.NET Core Web API
- API Controllers
- Routing
- HTTP GET Requests
- IActionResult
- Ok() and NotFound()
- Swagger
- Postman
- Minimal APIs

---

## What I Implemented

### 1. ItemsController
Created an API controller named **ItemsController**.

### GET /api/items
Returns a list of items:
- Laptop
- Mouse
- Keyboard

### GET /api/items/{id}
Returns a single item by its ID.

If the ID does not exist, the API returns:
- HTTP 404 Not Found
- "Item not found"

---

### 2. Minimal API

Created two Minimal API endpoints:

#### GET /minimal/items

Returns:
- Laptop
- Mouse
- Keyboard

#### GET /minimal/items/{id}

Returns a single item based on its ID.

If the item does not exist, returns:
- HTTP 404 Not Found
- "Item not found"

---

## Testing

The API was tested successfully using:

- Swagger UI
- Postman

Verified:
- Successful responses (200 OK)
- Not Found responses (404)

---

## Technologies Used

- C#
- ASP.NET Core Web API
- Controllers
- Minimal APIs
- Swagger
- Postman
- Visual Studio Code

---

## Outcome

By the end of Day 04, I understood the difference between Controller APIs and Minimal APIs, created REST endpoints, and tested them successfully using Swagger and Postman.
