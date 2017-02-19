using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageManager.Repositories
{
    public class PackageRepository : IRepository<IPackage>
    {
        private ICollection<IPackage> packages;
        private ILogger logger;

        public PackageRepository(ILogger logger, ICollection<IPackage> packages = null)
        {
            if (logger == null)
            {
                throw new ArgumentNullException();
            }

            this.logger = logger;

            if (packages == null)
            {
                this.packages = new HashSet<IPackage>();
            }
            else
            {
                this.packages = packages;
            }
        }

        public void Add(IPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("The package cannot be null");
            }

            var packageFound = this.packages.SingleOrDefault(x => x.Name == package.Name);

            if (packageFound == null)
            {
                this.logger.Log(string.Format("{0}: The package was added!", package.Name));
                this.packages.Add(package);
                return;
            }

            if (package.CompareTo(packageFound) == 0)
            {
                this.logger.Log(string.Format("{0}: Package with the same version is already installed!", package.Name));
                this.logger.Log("Aborting");
                this.logger.Log("Try to install another version");
                return;
            }
            else if (package.CompareTo(packageFound) > 0)
            {
                this.Update(package);
            }
            else
            {
                this.logger.Log(string.Format("{0}: There is a package with newer version!", package.Name));
                this.logger.Log("Aborting");
                return;
            }
        }

        public IPackage Delete(IPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("Package cannot be null");
            }

            var packageFound = this.packages.SingleOrDefault(x => x.Equals(package));

            if (packageFound == null)
            {
                this.logger.Log(string.Format("{0}: The package does not exist!", package.Name));
                throw new ArgumentNullException("Package cannot be null");
            }

            var allDependencies = this.packages.SelectMany(x => x.Dependencies).Where(x => x.Equals(package));

            if (allDependencies.Count() > 0)
            {
                this.logger.Log(string.Format("{0}: The package is a dependency and could not be removed!", package.Name));
                this.logger.Log("Aborting");
                this.logger.Log("Please remove the dependencies first!");
            }

            this.packages.Remove(packageFound);
            return package;
        }

        public virtual bool Update(IPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("The package cannot be null");
            }

            var packageFound = this.packages
                .SingleOrDefault(x => x.Name == package.Name);

            if (packageFound == null)
            {
                this.logger.Log(string.Format("{0}: The package does not exist!", package.Name));
                throw new ArgumentNullException("The package cannot be null");
            }

            if (package.CompareTo(packageFound) > 0)
            {
                packageFound.Version = package.Version;
                return true;
            }

            else if (package.CompareTo(packageFound) < 0)
            {
                this.logger.Log(string.Format("{0}: The package has higher version than you are trying to install!", package.Name));
                throw new ArgumentException();
            }

            else
            {
                this.logger.Log(string.Format("{0}: Package with the same version is already installed!", package.Name));
                return false;
            }
        }

        // Gets all the packages in the repository
        public IEnumerable<IPackage> GetAll()
        {
            #region
            this.AddPackage();
            #endregion
            this.logger.Log("All packages");
            return this.packages;
        }

        // Temporary method for test
        private void AddPackage()
        {
            this.packages.Add(new Package("test", new PackageVersion(1, 1, 1, VersionType.alpha)));
        }
    }
}
