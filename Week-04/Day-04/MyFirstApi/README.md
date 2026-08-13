# Week 04 - Day 04: Input Validation with FluentValidation

## What I Learned

- Difference between DataAnnotations and FluentValidation
- Using FluentValidation in ASP.NET Core Web API
- Creating validators for request models
- Writing validation rules
- Validating Create and Update requests
- Integrating FluentValidation into the ASP.NET Core pipeline
- Returning structured validation error responses
- Understanding 400 Bad Request responses
- Testing validation rules using Postman

## What I Did

- Installed FluentValidation and its ASP.NET Core integration package.
- Created `CreateBookRequest` for Create Book requests.
- Created `CreateBookValidator` to validate Create Book requests.
- Added validation rules for Title, Author, and Category.
- Created `UpdateBookRequest` for Update Book requests.
- Created `UpdateBookValidator` to validate Update Book requests.
- Registered FluentValidation validators in `Program.cs`.
- Updated the Create Book endpoint to use `CreateBookRequest`.
- Updated the Update Book endpoint to use `UpdateBookRequest`.
- Tested invalid requests and confirmed `400 Bad Request` responses.
- Tested each validation rule individually using Postman.
- Verified specific validation error messages for invalid Title, Author, and Category values.
