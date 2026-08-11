namespace MyFirstApi.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from Dependancy Injection!";
        }
    }
}