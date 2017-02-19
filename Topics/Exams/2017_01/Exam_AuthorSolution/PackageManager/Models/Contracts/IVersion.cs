using PackageManager.Enums;

namespace PackageManager.Models.Contracts
{
    public interface IVersion
    {
        int Major { get; }

        int Minor { get; }

        int Patch { get; }

        VersionType VersionType { get; }
    }
}
