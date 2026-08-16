# Week 04 - Authentication, Authorization, Validation & API Security

During Week 04, I worked on securing an ASP.NET Core Web API. I started with user registration using ASP.NET Core Identity, then added JWT Authentication, Authorization using roles and policies, input validation using FluentValidation, and API security using Rate Limiting, CORS, and security headers.

## Day 01 - ASP.NET Core Identity

### What I Learned
- The purpose of ASP.NET Core Identity.
- How Identity is used to manage users.
- How UserManager is used to create users.
- How user registration works in an ASP.NET Core API.

### What I Did
- Configured ASP.NET Core Identity.
- Created a Register endpoint in AuthController.
- Used UserManager to create users.
- Tested the Register endpoint using Postman.

---

## Day 02 - JWT Authentication

### What I Learned
- The difference between Authentication and Authorization.
- How user login works.
- What JWT (JSON Web Token) is.
- How JWT tokens are generated and used for authentication.
- How Claims store information about the authenticated user.

### What I Did
- Created a Login endpoint in AuthController.
- Used SignInManager to verify user credentials.
- Generated a JWT Token after successful login.
- Added user information as Claims inside the token.
- Configured JWT Authentication.
- Set an expiration time for the JWT Token.
- Tested Login and JWT Authentication using Postman.

---

## Day 03 - Authorization, Roles & Policies

### What I Learned
- How Authorization controls access to API endpoints.
- How protected endpoints work.
- How Role-Based Authorization works.
- How Policy-Based Authorization works.
- The difference between 401 Unauthorized and 403 Forbidden.

### What I Did
- Protected endpoints using [Authorize].
- Applied Role-Based Authorization.
- Created a policy called RequireAdminEmail.
- Used an Email Claim as a requirement for the policy.
- Tested protected endpoints and authorization responses using Postman.

---

## Day 04 - Input Validation with FluentValidation

### What I Learned
- Why input validation is important.
- How FluentValidation is used to validate incoming API data.
- How RuleFor is used to define validation rules.
- How the API handles invalid input.

### What I Did
- Added FluentValidation to the API.
- Created CreateBookValidator.
- Added validation rules for Title, Author, and Category.
- Created UpdateBookValidator for update requests.
- Tested valid and invalid input using Postman.
- Verified that invalid input returns 400 Bad Request with validation errors.

---

## Day 05 - Securing the API

### What I Learned
- How Rate Limiting helps protect the API from excessive requests.
- Why sensitive endpoints such as Login need stricter Rate Limiting.
- How CORS controls which origins can access the API.
- How HTTPS redirection, HSTS, and security headers improve API security.
- How Entity Framework Core helps prevent SQL Injection by parameterizing queries.

### What I Did
- Configured Rate Limiting.
- Added a general Rate Limiting policy.
- Added a stricter Rate Limiting policy for the Login endpoint.
- Applied Rate Limiting to the Login endpoint.
- Configured CORS for the API.
- Added HTTPS redirection.
- Added HSTS.
- Added security headers.
- Reviewed SQL Injection prevention with Entity Framework Core.

---

## Week 04 Summary

During this week, I built a complete authentication and authorization flow for an ASP.NET Core Web API.

The user can register using ASP.NET Core Identity, log in and receive a JWT Token, and use the token to access protected endpoints.

I used Role-Based and Policy-Based Authorization to control access to endpoints and FluentValidation to validate incoming data.

Finally, I improved the security of the API using Rate Limiting, CORS, HTTPS redirection, HSTS, security headers, and Entity Framework Core's parameterized queries.

I used Postman throughout the week to test the API endpoints and verify different responses.

### Authentication Flow

Register  
↓  
Login  
↓  
JWT Token  
↓  
Authentication  
↓  
Authorization  
↓  
Role / Policy Check  
↓  
Protected Endpoint

## Technologies & Tools

- C#
- ASP.NET Core Web API
- ASP.NET Core Identity
- Entity Framework Core
- JWT Authentication
- Role-Based Authorization
- Policy-Based Authorization
- FluentValidation
- Rate Limiting
- CORS
- HTTPS / HSTS
- Postman
- Visual Studio Code
