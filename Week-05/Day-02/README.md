# Week 5 - Day 02: Mocking Dependencies with Moq

## What I Learned

Today I learned how to use mocking in unit testing to isolate service logic from external dependencies.

I learned:

- What mocking is and why it is useful in unit testing.
- How to use Moq with xUnit.
- How to mock a repository interface instead of using the real database.
- How to configure a mock to return predefined data using `Setup()` and `ReturnsAsync()`.
- How to simulate exceptions using `ThrowsAsync()`.
- How to verify interactions with mocked dependencies using `Verify()`.
- How to use `Times.Once` to ensure that a method is called exactly once.
- How mocking helps make unit tests isolated, fast, and independent from external systems.

## What I Did

I continued working on the **Cardiac Patient Monitoring System** and created unit tests for `PatientService`.

I:

- Added the Moq package to the xUnit test project.
- Used `IGenericRepository<Patient>` as the dependency to mock.
- Mocked the repository to return predefined patient data.
- Tested `GetAllPatientsAsync()` to verify that the service returns the expected patients.
- Mocked a repository exception using `ThrowsAsync()`.
- Tested the service behavior when the repository throws an exception.
- Used `Verify()` and `Times.Once` to confirm that `GetAllAsync()` is called exactly once.
- Followed the Arrange-Act-Assert pattern when writing the tests.
- Ran the unit tests using `dotnet test`.
- Successfully passed all tests.

## Tools Used

- .NET
- C#
- xUnit
- Moq
- Visual Studio Code

## Result

All unit tests passed successfully:

- Passed: 9
- Failed: 0
- Skipped: 0
