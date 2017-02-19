using PackageManager.Enums;

namespace PackageManager.Core.Contracts
{
    internal interface IInstaller<T>
    {
        InstallerOperation Operation { get; set; }

        string BasicFolder { get; }

        void PerformOperation(T obj);
    }
}
