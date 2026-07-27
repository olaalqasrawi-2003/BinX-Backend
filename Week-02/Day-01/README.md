# Day 1 - Generics & Advanced Collections

## Topics Covered

- Why Generics
- Generic Classes
- Generic Constraints
- Collection Interfaces

---

## Hands-on Lab

Implemented a generic repository.

### Features

- Created a generic `Repository<T>` class.
- Applied the `where T : class` generic constraint.
- Added an `Add(T item)` method.
- Added a `GetAll()` method that returns `IReadOnlyList<T>`.
- Added a `Find(Func<T, bool> predicate)` method.
- Tested the repository with two Week 1 domain models (`User` and `Admin`).
- Added a comment explaining why the generic constraint is used.

---

## What I Learned

- How generics improve code reusability and type safety.
- How generic constraints restrict the allowed types.
- The difference between `List<T>`, `IReadOnlyList<T>`, and `IEnumerable<T>`.
- Why returning `IReadOnlyList<T>` is safer than returning `List<T>`.
