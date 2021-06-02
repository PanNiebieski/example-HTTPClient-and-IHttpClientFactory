using System;
using System.Threading.Tasks;

namespace ConsoleHTTPClientTester
{
    public class Program
    {
        private static async Task Main()
        {
            MyServiceClient m = new MyServiceClient();

            var todo = await m.GetToDo();

            Console.WriteLine(todo.Title);
            Console.WriteLine(todo.Completed);
        }
    }
}
