namespace PackageManager.Core.Contracts
{
    internal interface IManager
    {
        bool Create(string path);

        bool Delete(string path);
    }
}
