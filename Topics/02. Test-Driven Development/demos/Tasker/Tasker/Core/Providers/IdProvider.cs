using Tasker.Core.Contracts;

namespace Tasker.Core.Providers
{
    public class IdProvider : IIdProvider
    {
        private static int currentId = 0;

        public int NextId()
        {
            return currentId++;
        }
    }
}
