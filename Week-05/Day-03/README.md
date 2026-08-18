# Week 5 - Day 03: Integration Testing with WebApplicationFactory

## What I Learned

Today I learned how to perform integration testing for an ASP.NET Core Web API using WebApplicationFactory and xUnit.

I learned:

- How integration testing verifies multiple parts of an application working together.
- How to use WebApplicationFactory to run the API in a test environment.
- How to send HTTP requests using HttpClient during integration tests.
- How to test successful and error responses for API endpoints.
- How to use an In-Memory database instead of the real application database during testing.
- How to test protected endpoints using a valid test JWT.

## What I Did

I continued working on the Cardiac Patient Monitoring System and added integration tests for the Patients API.

I:

- Added Microsoft.AspNetCore.Mvc.Testing to the test project.
- Created a WebApplicationFactory-based integration test setup.
- Configured an In-Memory database for integration testing.
- Added test patient data to the test database.
- Tested the Get Patient By ID happy path.
- Verified the full patient response body.
- Tested the Get Patient By ID not-found path and verified the 404 response.
- Created and attached a valid test JWT.
- Tested a protected Patients endpoint using the valid JWT.
- Ran all tests successfully using dotnet test.

## Tools Used

-  Microsoft.AspNetCore.Mvc.Testing
- xUnit

## Result

All tests passed successfully:

- Passed: 12
- Failed: 0
- Skipped: 0