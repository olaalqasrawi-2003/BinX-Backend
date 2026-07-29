# Day 3 - Async/Await Deep Dive & Concurrency Basics

## Topics Covered

- Task-based Asynchronous Programming
- Async/Await
- Sequential Execution
- Concurrent Execution with Task.WhenAll
- Cancellation Tokens

---

## Hands-on Lab

Implemented asynchronous operations and compared sequential and concurrent execution.

### Features

- Created three asynchronous methods to simulate different data sources.
- Used `Task.Delay()` to simulate long-running operations.
- Executed async methods sequentially using `await`.
- Measured execution time using `Stopwatch`.
- Executed multiple tasks concurrently using `Task.WhenAll()`.
- Compared sequential and concurrent execution times.
- Implemented cancellation using `CancellationToken`.
- Handled `OperationCanceledException` when the operation was cancelled.

---

## What I Learned

- How `async` and `await` work together.
- The difference between sequential and concurrent execution.
- How `Task.WhenAll()` improves performance for independent tasks.
- How to measure execution time using `Stopwatch`.
- How to cancel an asynchronous operation using `CancellationToken`.
