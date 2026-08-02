# Day 01 - REST API Design Principles & Resource Modeling

## Objective

The goal of this project is to build a simple RESTful API using ASP.NET Core Web API.

The API follows REST principles by:
- Using resource-based URLs.
- Supporting CRUD operations.
- Returning proper HTTP status codes.
- Using API versioning.
- Implementing a nested resource endpoint.

---

## Project Domain

Library Catalog

### Resources

- Books
- Authors
- Categories
- Members
- Loans

Primary Resource:
- Books

---

## API Endpoints

### Books Resource

| Method | Endpoint | Description | Success Status |
|--------|----------|-------------|----------------|
| GET | /api/v1/Books | Get all books | 200 OK |
| GET | /api/v1/Books/{id} | Get a book by ID | 200 OK |
| POST | /api/v1/Books | Create a new book | 201 Created |
| PUT | /api/v1/Books/{id} | Update an existing book | 200 OK |
| DELETE | /api/v1/Books/{id} | Delete a book | 204 No Content |

### Nested Resource

| Method | Endpoint | Description | Success Status |
|--------|----------|-------------|----------------|
| GET | /api/v1/categories/{category}/books | Get books by category | 200 OK |

---

# API Testing Report

The API was tested using Postman.

| Test | Method | Status |
|------|--------|--------|
| Get all books | GET | ✅ 200 OK |
| Get book by ID | GET | ✅ 200 OK |
| Create book | POST | ✅ 201 Created |
| Update book | PUT | ✅ 200 OK |
| Delete book | DELETE | ✅ 204 No Content |
| Get books by category | GET | ✅ 200 OK |
| Invalid category | GET | ✅ 404 Not Found |

---

## Screenshots
### GET - Get All Books
![GET All Books](Books.jpg)

---

### GET - Get Book By ID
![GET Book By ID](image-6.png)

---

### POST - Create Book

![POST Create Book](image-5.png)

---

### PUT - Update Book

![PUT Update Book](image.png)

---

### DELETE - Delete Book

![DELETE Book](image-4.png)

---

### GET - Books By Category

![Books By Category](image-1.png)

---

### GET - Invalid Category

![Invalid Category](image-2.png)