# Week 04 - Day 05: Securing the API

## What I Learned

- What Rate Limiting is and how it helps protect an API from repeated requests.
- How to use a stricter Rate Limiting policy for sensitive endpoints like login.
- What CORS (Cross-Origin Resource Sharing) is and why it should allow only specific origins.
- How HTTPS redirection and HSTS improve API security.
- How Entity Framework Core helps prevent SQL Injection by parameterizing queries.
- Why unparameterized raw SQL queries can create SQL Injection risks.

## What I Did

- Configured Rate Limiting using the built-in .NET Rate Limiting middleware.
- Created a general Rate Limiting policy allowing 10 requests per minute.
- Created a stricter login policy allowing 3 requests per minute.
- Applied the stricter Rate Limiting policy to the login endpoint.
- Created a named CORS policy that allows only a specific frontend origin.
- Added the CORS policy to the middleware pipeline.
- Enabled HTTPS redirection.
- Enabled HSTS in the middleware pipeline.
- Reviewed the project for raw SQL queries.
- Confirmed that the project does not use unparameterized raw SQL string interpolation.

## Tools Used

- Built-in .NET Rate Limiting
- ASP.NET Core
