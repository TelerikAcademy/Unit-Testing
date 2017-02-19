using ArmyOfCreatures.Logic;

namespace ArmyOfCreatures.Console
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}
