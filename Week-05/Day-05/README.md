# Week 5 - Day 5: Applying Testing to the Chosen Project

## Project
**Cardiac Patient Monitoring System**

The Cardiac Patient Monitoring System is an ASP.NET Core Web API used to manage cardiac patients, vital signs, medications, and appointments.

## Day 5 Objective

The goal of Day 5 was to apply and review the testing concepts from Week 5 on the Cardiac Patient Monitoring System, focus on important project logic, and run the complete test suite.

## Existing Test Suite

The project already included tests created during the previous days of Week 5.

These tests included:

- Unit tests using xUnit.
- Heart rate business logic tests.
- Parameterized tests using Theory and InlineData.
- Mock tests using Moq.
- Patient service tests.
- Integration tests using WebApplicationFactory.
- JWT-protected endpoint testing.
- Error scenario testing.

## High-Risk Logic

For Day 5, I reviewed important logic in the project and focused on areas such as:

- Heart rate validation.
- Patient medication summary.
- Patient health summary.

The heart rate logic was already covered by unit tests from the previous work.

## Medication Summary Test

A new test was added for:

`GetPatientMedicationSummaryAsync()`

The test uses the Entity Framework Core InMemory Database and verifies that the service correctly returns:

- Patient ID
- Patient name
- Medication name
- Dosage

The test was executed successfully.

## Integration Testing

The project already contained integration tests for important patient endpoints.

The existing integration tests verify that:

- Requesting an existing patient returns a successful response.
- Requesting a patient that does not exist returns `404 Not Found`.
- A protected endpoint can be accessed using a valid JWT token.

These tests use a custom `WebApplicationFactory`.

## Error Handling

Centralized error handling was added during the previous work in Week 5 using middleware.

This setup was kept as part of the project and provides a common way to handle application errors.

## Full Test Suite

After reviewing the tests and adding the medication summary test, I ran the complete test suite using:

```bash
dotnet test
```

## Test Results

The final test result was:

- Passed: 13
- Failed: 0
- Skipped: 0
- Total: 13

All tests passed successfully.

## Day 5 Summary

On Day 5, I reviewed the testing work completed during Week 5 and applied it to the Cardiac Patient Monitoring System.

I added a test for the patient medication summary, reviewed the existing unit, mock, and integration tests, and ran the complete test suite.

The final test suite contained 13 tests, and all tests passed successfully.