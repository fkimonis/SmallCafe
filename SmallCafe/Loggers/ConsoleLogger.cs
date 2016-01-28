using System;

namespace SmallCafe
{

    public class ConsoleLogger : IConsoleLogger
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
