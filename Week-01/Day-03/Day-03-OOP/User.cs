public class User : INotifiable
{
private string _name;
private string _email;
    public string Name
    {
        get => _name;
        set => _name = value;
    }
      public string Email
    {
        get => _email;
        set => _email = value;
    }
    public User(string name , string email)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
        if(string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be empty");
        }
        _name = name;
        _email = email;
    }
    public virtual void ShowRole()
    {
        Console.WriteLine("Role : User");
    }
    public void Notify()
    {
        Console.WriteLine($"Notification sent to {Name}");
    }
}