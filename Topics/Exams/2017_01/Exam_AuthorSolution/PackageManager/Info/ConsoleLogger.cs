using System;

using PackageManager.Info.Contracts;

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
