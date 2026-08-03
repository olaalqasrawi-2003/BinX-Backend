// See https://aka.ms/new-console-template for more information
Console.WriteLine("Library Catalog Entities and Attributes");
Console.WriteLine();

Console.WriteLine("Books: Id, Title, AuthorId, CategoryId");
Console.WriteLine("Authors: Id, Name");
Console.WriteLine("Categories: Id, Name");
Console.WriteLine("Members: Id, Name, Email");
Console.WriteLine("Loans: Id, BookId, MemberId, LoanDate, ReturnDate");
Console.WriteLine();

Console.WriteLine("First Normal Form (1NF)");
Console.WriteLine();

Console.WriteLine("Customers");
Console.WriteLine("Id | Name | Email");
Console.WriteLine();

Console.WriteLine("Orders");
Console.WriteLine("Id | CustomerId | OrderDate | Total");
Console.WriteLine();

Console.WriteLine("Products");
Console.WriteLine("Id | Name | Price");
Console.WriteLine();

Console.WriteLine("OrderItems");
Console.WriteLine("Id | OrderId | ProductId | Quantity");
Console.WriteLine();

Console.WriteLine();
Console.WriteLine("Choosing Column Types");
Console.WriteLine();

Console.WriteLine("Customers");
Console.WriteLine("Id: INT");
Console.WriteLine("Name: VARCHAR(100)");
Console.WriteLine("Email: VARCHAR(100)");
Console.WriteLine();

Console.WriteLine("Orders");
Console.WriteLine("Id: INT");
Console.WriteLine("CustomerId: INT");
Console.WriteLine("OrderDate: DATE");
Console.WriteLine("Total: DECIMAL(10,2)");
Console.WriteLine();

Console.WriteLine("Products");
Console.WriteLine("Id: INT");
Console.WriteLine("Name: VARCHAR(100)");
Console.WriteLine("Price: DECIMAL(10,2)");
Console.WriteLine();

Console.WriteLine("OrderItems");
Console.WriteLine("Id: INT");
Console.WriteLine("OrderId: INT");
Console.WriteLine("ProductId: INT");
Console.WriteLine("Quantity: INT");