using System;
using System.Collections.Generic;

namespace PackageManager.Models.Contracts
{
    public interface IPackage : IComparable<IPackage>
    {
        string Name { get; }

        string Url { get; }

        IVersion Version { get; set; }

        ICollection<IPackage> Dependencies { get; }

        bool Equals(object obj);

        int GetHashCode();
    }
}
