Repository<User> userRepository = new Repository<User>();

userRepository.Add(new User("Ola"));
userRepository.Add(new User("Ahmad"));

Console.WriteLine("Users:");

foreach (User user in userRepository.GetAll())
{
    Console.WriteLine(user.Name);
}

Console.WriteLine();

Repository<Product> productRepository = new Repository<Product>();

productRepository.Add(new Product("Laptop"));
productRepository.Add(new Product("Mouse"));

Console.WriteLine("Products:");

foreach (Product product in productRepository.GetAll())
{
    Console.WriteLine(product.Name);
}