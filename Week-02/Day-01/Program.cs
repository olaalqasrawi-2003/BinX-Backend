Repository<User> userRepository = new Repository<User>();

userRepository.Add(new User("Ola"));
userRepository.Add(new User("Ahmad"));

Console.WriteLine("Users:");

foreach (User user in userRepository.GetAll())
{
    Console.WriteLine(user.Name);
}

Console.WriteLine();

Repository<Admin> adminRepository = new Repository<Admin>();

adminRepository.Add(new Admin("Sara"));
adminRepository.Add(new Admin("Ali"));

Console.WriteLine("Admins:");

foreach (Admin admin in adminRepository.GetAll())
{
    Console.WriteLine(admin.Name);
}