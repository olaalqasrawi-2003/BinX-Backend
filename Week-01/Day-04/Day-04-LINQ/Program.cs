// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

List<User> users = new List<User>
{
    new User("Ola", "ola@gmail.com", "User"), 
    new User("Ahmed", "ahmed@gmail.com", "Admin"), 
    new User("Sara", "sara@gmail.com", "User"), 
    new User("Ali", "ali@gmail.com", "Admin"), 
    new User("Lina", "lina@gmail.com", "User"), 
    new User("Noor", "noor@gmail.com", "User"), 
    new User("Mohammad", "mohammad@gmail.com", "Admin"), 
    new User("Rana", "rana@gmail.com", "User")
};

Console.WriteLine("=== All Users ===");
foreach (User user in users)
{
    Console.WriteLine($"{user.Name} - {user.Email} - {user.Role}");
}

List<User> admins = users.Where(user => user.Role == "Admin").ToList();
Console.WriteLine("=== Admin Users ===");

foreach (User admin in admins)
{
    Console.WriteLine($"{admin.Name} - {admin.Email} - {admin.Role}");
}

List<string> userName = users.Select (user => user.Name).ToList();
Console.WriteLine();
Console.WriteLine("=== User Names ===");

foreach (string name in userName)
{
    Console.WriteLine(name);
}

int totalUsers = users.Count();
Console.WriteLine();
Console.WriteLine($"Tatal number of users: {totalUsers}");

Console.WriteLine();
Console.WriteLine("Loading data...");
try
{
    string? input = Console.ReadLine();
    int userNumber = int.Parse(input!);

    Console.WriteLine($"User number entered: {userNumber}");}
    catch(FormatException){
        Console.WriteLine("Invalid input.  Please enter numbers only.");
    }


string result = await GetMessageAsync();
Console.WriteLine(result);

async Task<string> GetMessageAsync()
{
    await Task.Delay(2000);
    return "Data loaded successfuly!";
}