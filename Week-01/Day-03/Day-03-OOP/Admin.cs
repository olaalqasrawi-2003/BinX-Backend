public class Admin : User
{
    public Admin (string name , string email) : base(name , email)
    {
    }
    public override void ShowRole()
    {
        Console.WriteLine("Role : Admin");
    }
}