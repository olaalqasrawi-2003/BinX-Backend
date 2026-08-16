using System.Reflection.Metadata.Ecma335;

namespace MyFirstApi.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from Dependancy Injection!";
        }

        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}