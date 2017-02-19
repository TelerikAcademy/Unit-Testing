using PackageManager.Core.Contracts;
using System.IO;

namespace PackageManager.Core
{
    public class DirectoryManager : IManager
    {
        public bool Create(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return true;
            }

            return false;
        }

        public bool Delete(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                return true;
            }

            return false;
        }
    }
}
