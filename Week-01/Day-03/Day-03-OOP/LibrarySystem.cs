public class LibrarySystem : INotifiable
{
    public string SystemName {get; set;}
    public LibrarySystem(string systemName)
    {
         SystemName =  systemName;
    }
    public void Notify()
    {
        Console.WriteLine($"Notification sent srom { SystemName}");
    }
}