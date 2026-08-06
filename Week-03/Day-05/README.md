# Week 03 - Day 05: API Testing & Postman Documentation

## Overview

On Day 05, I focused on organizing, testing, and documenting the Library API using Postman. I created a structured Postman collection, organized requests into folders, tested both successful and error scenarios, configured an environment using a base URL variable, exported the collection and environment files, and documented the testing results.

---

## Learning Objectives

- Organize API requests into a structured Postman Collection.
- Test REST API endpoints using Postman.
- Validate successful and failure responses.
- Write basic Postman test scripts.
- Use Postman Environment variables.
- Export Postman Collections and Environments.
- Document API testing results.

---

## Topics Covered

- Postman Collections
- Postman Folders
- Postman Environment
- Environment Variables
- REST API Testing
- Success & Error Responses
- Postman Test Scripts
- API Documentation

---

## Tasks Completed

### Organizing Requests

- Created a Postman Collection named **Week 03 - Library API**.
- Created a **Books** folder inside the collection.
- Organized all Day 04 API requests inside the folder.

---

### API Testing

Tested all CRUD endpoints:

- GET - Get All Books
- GET - Get Book By Id
- POST - Create Book
- PUT - Update Book
- DELETE - Delete Book

---

### Error Testing

Created error scenarios for the API:

- Book Not Found
- Invalid Book Request

Verified that the API returned the correct HTTP status codes for invalid requests.

---

### Postman Test Scripts

Added basic test scripts to verify expected response status codes for multiple requests.

---

### Environment Configuration

Created a Postman Environment named **Week 03 Local**.

Configured the **baseUrl** variable and updated all requests to use it instead of writing the full URL repeatedly.

---

### Exporting Files

Exported:

- Postman Collection
- Postman Environment

---

### Documentation

Documented the API testing process and saved the testing screenshots inside the **Screenshots** folder.

---

## Technologies Used

- ASP.NET Core Web API
- Postman
- REST API
- JSON

---



