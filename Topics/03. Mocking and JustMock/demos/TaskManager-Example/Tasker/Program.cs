using Tasker.Core;
using Tasker.Core.Providers;
using Tasker.Models;

namespace Tasker
{
    public class Startup
    {
        public static void Main()
        {
            var idProvider = new IdProvider();
            var consoleLogger = new ConsoleLogger();

            var manager = new TaskManager(idProvider, consoleLogger);
            var task = new Task("Some task");

            manager.Add(task);
        }
    }
}
