using PackageManager.Repositories.Contracts;

namespace PackageManager.Models.Contracts
{
    public interface IProject
    {
        string Name { get; }

        string Location { get; }

        IRepository<IPackage> PackageRepository { get; }
    }
}
