using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;

namespace PackageManager.Models
{
    public class Package : IPackage
    {
        public Package(string name, IVersion version, ICollection<IPackage> dependencies = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }

            if (version == null)
            {
                throw new ArgumentNullException();
            }

            if (dependencies == null)
            {
                this.Dependencies = new HashSet<IPackage>();
            }
            else
            {
                this.Dependencies = dependencies;
            }

            this.Name = name;
            this.Version = version;
            this.Url = string.Format("{0}.{1}.{2}-{3}", this.Version.Major, this.Version.Minor, this.Version.Patch, this.Version.VersionType);
        }

        public ICollection<IPackage> Dependencies { get; private set; }

        public string Name { get; private set; }

        public string Url { get; private set; }

        public IVersion Version { get; set; }

        public int CompareTo(IPackage other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("The object cannot be null");
            }

            if (this.Name != other.Name)
            {
                throw new ArgumentException();
            }

            var thisFersionFinal = this.Version.Major * 1000 + this.Version.Minor * 100 + this.Version.Patch * 10 + (int)this.Version.VersionType;
            var otherFersionFinal = other.Version.Major * 1000 + other.Version.Minor * 100 + other.Version.Patch * 10 + (int)other.Version.VersionType;

            if (thisFersionFinal > otherFersionFinal)
            {
                return 1;
            }
            else if (thisFersionFinal < otherFersionFinal)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException();
            }

            if (!(obj is IPackage))
            {
                throw new ArgumentException("The object must be IPackage");
            }

            var packageToCompare = (IPackage)obj;

            return this.Name == packageToCompare.Name &&
                   this.Version.Major == packageToCompare.Version.Major &&
                   this.Version.Minor == packageToCompare.Version.Minor &&
                   this.Version.Patch == packageToCompare.Version.Patch &&
                   this.Version.VersionType == packageToCompare.Version.VersionType;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
