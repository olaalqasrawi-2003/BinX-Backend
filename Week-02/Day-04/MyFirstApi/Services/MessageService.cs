namespace MyFirstApi.Services
{
    public class MessageSevice : IMessageSevice
    {
        public string GetMessage()
        {
            return "Hello from Dependancy Injection!";
        }
    }
}