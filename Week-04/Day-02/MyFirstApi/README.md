# Week 04 - Day 02: JWT Authentication & Token Issuance

## What I Learned

- JWT structure and claims
- Creating a login endpoint
- Checking user credentials using SignInManager
- Generating a JWT token after successful login
- Adding user ID and email as claims
- Configuring JWT bearer authentication
- Setting token expiration
- Testing JWT using Postman
- Decoding the token and checking its payload

## What I Did

- Added JWT support to the existing API project.
- Added JWT configuration for issuer, audience, and signing key.
- Configured JWT bearer authentication in `Program.cs`.
- Updated `AuthController` to use `SignInManager`.
- Created a login endpoint.
- Returned `401 Unauthorized` for invalid login attempts.
- Generated a signed JWT token after successful login.
- Added the user ID and email inside the token claims.
- Set the token expiration time to 15 minutes.
- Tested both invalid and valid login requests using Postman.
- Decoded the generated token and checked the claims.

## Login Endpoint

```http
POST /api/Auth/login
```

For invalid credentials:

```text
401 Unauthorized
```

For valid credentials, the API returns a JWT token.

## JWT Claims

The generated token contains:

- User ID
- Email
- Expiration time
- Issuer
- Audience

## Token Expiration

The JWT token is set to expire after:

```text
15 minutes
```

## Tools Used

- ASP.NET Core Identity
- System.IdentityModel.Tokens.Jwt
- Postman
