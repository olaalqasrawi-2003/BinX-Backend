User user = new User("Ola" , "ola@gmail.com");
Admin admin = new Admin("Ahmed" , "admin@gmail.com");

user.ShowRole();
admin.ShowRole();

UserRecord record = new UserRecord("Sara" , "sara@gmail.com");

Console.WriteLine($"Record:{record.Name} - {record.Email}");

LibrarySystem library = new LibrarySystem("Main Library");
INotifiable[] notifiables =
{
    user, 
    library
};

foreach (INotifiable item in notifiables)
{
    item.Notify();
}