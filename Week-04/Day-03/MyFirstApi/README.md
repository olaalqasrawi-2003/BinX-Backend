# Week 04 - Day 03: Protecting Routes with Authorization & Role-Based Access Control

## What I Learned

- Difference between authentication and authorization
- Protecting endpoints using Authorize
- Role-based authorization
- Adding roles to users
- Using roles with JWT
- Policy-based authorization
- Using claims in authorization policies
- Testing protected endpoints using Postman
- Understanding 403 Forbidden responses

## What I Did

- Added authorization to the existing API project.
- Protected API endpoints using `Authorize`.
- Added roles to users.
- Added user roles to the JWT token claims.
- Tested role-based authorization.
- Created a custom authorization policy called `RequireAdminEmail`.
- Configured the policy to check the user's email claim.
- Applied the policy to the Get Books endpoint.
- Tested authorized and forbidden requests using Postman.
- Tested access using different users and roles.

## Role-Based Authorization

Protected endpoints were tested using user roles.

A user with the required role can access the endpoint.

A user without the required role receives:

```text
403 Forbidden
```

## Policy-Based Authorization

A custom policy was created:

```text
RequireAdminEmail
```

The policy checks the email claim before allowing access to the protected endpoint.

## Postman Testing

The authorization flow was tested using Postman.

Tests included:

- Request without a token
- Request with a valid JWT token
- Role-based access
- Policy-based access
- 403 Forbidden response

## Tools Used

- ASP.NET Core Identity
- JWT Bearer Authentication
- Authorization Roles and Policies
- Postman
