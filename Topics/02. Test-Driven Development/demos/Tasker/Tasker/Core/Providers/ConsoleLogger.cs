using System;
using Tasker.Core.Contracts;

namespace Tasker.Core.Providers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
