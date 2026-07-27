// See https://aka.ms/new-console-template for more information
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;

List <Customer> customers = new()
{
    new Customer {Id = 1, Name = "Ola"},
    new Customer {Id = 2, Name = "Ahmed"},
    new Customer {Id = 3, Name = "Sara"},
    new Customer {Id = 4, Name = "Ali"},
    new Customer {Id = 5, Name = "Lina"},
    new Customer {Id = 6, Name = "Omar"}
 
};

List <Order> orders = new()
{
    new Order {Id = 1, CustomerId = 1, Amount = 500},
    new Order {Id = 2, CustomerId = 2, Amount = 250},
    new Order {Id = 3, CustomerId = 3, Amount = 300},
    new Order {Id = 4, CustomerId = 4, Amount = 700},
    new Order {Id = 5, CustomerId = 5, Amount = 150},
    new Order {Id = 6, CustomerId = 6, Amount = 900}
 
};

var orderByCustomer = orders.GroupBy(o => o.CustomerId).Select(g => new
{
    CustomerId = g.Key,Total = g.Sum(o => o.Amount)
});

Console.WriteLine("Orders Summary:");
foreach(var item in orderByCustomer)
{
    Console.WriteLine($"Customer{item.CustomerId} - Total: {item.Total}");
}

var customerOrders = customers.Join(
    orders,
    customer => customer.Id,
    order => order.CustomerId,
    (customer, order) => new
    {
        CustomerName = customer.Name,
        OrderAmount = order.Amount
    }
);

Console.WriteLine();
Console.WriteLine("Customer Orders:");

foreach (var item in customerOrders)
{
    Console.WriteLine($"{item.CustomerName} - {item.OrderAmount}");
}

List<CustomerWithOrders> customersWithOrders = new()
{
    new CustomerWithOrders
    {
        CustomerName = "Ola",
        Orders = new List<Order>
        {
            new Order { Id = 1, CustomerId = 1, Amount = 500 },
            new Order { Id = 2, CustomerId = 1, Amount = 250 }
        }
    },

    new CustomerWithOrders
    {
        CustomerName = "Ahmad",
        Orders = new List<Order>
        {
            new Order { Id = 3, CustomerId = 2, Amount = 300 },
            new Order { Id = 4, CustomerId = 2, Amount = 700 }
        }
    },

    new CustomerWithOrders
    {
        CustomerName = "Sara",
        Orders = new List<Order>
        {
            new Order { Id = 5, CustomerId = 3, Amount = 150 },
            new Order { Id = 6, CustomerId = 3, Amount = 900 }
        }
    }
};

var allOrders = customersWithOrders.SelectMany(customer => customer.Orders);
Console.WriteLine();
Console.WriteLine("All Orders:");

foreach (var order in allOrders)
{
    Console.WriteLine($"Order{order.Id} - Amount: {order.Amount}");
}

var highValueOrders = orders.Where(order => order.Amount >= 500);
orders.Add(new Order
{
    Id = 7,
    CustomerId = 6,
    Amount = 1200
});

Console.WriteLine();
Console.WriteLine("Deferred Execution:");

foreach (var order in highValueOrders)
{
    Console.WriteLine($"Order{order.Id} - Amount: {order.Amount}");
}