using PackageManager.Info.Contracts;
using System;

namespace PackageManager.Info
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
