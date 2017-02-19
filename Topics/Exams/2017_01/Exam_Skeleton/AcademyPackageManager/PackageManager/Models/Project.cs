using PackageManager.Repositories.Contracts;
using PackageManager.Repositories;
using PackageManager.Info;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Models
{
    public class Project : IProject
    {
        public Project(string name, string location, IRepository<IPackage> packages = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }

            if (location == null)
            {
                throw new ArgumentNullException();
            }

            if (packages == null)
            {
                this.PackageRepository = new PackageRepository(new ConsoleLogger());
            }
            else
            {
                this.PackageRepository = packages;
            }

            this.Name = name;
            this.Location = location;
        }

        public string Location { get; private set; }


        public string Name { get; private set; }

        public IRepository<IPackage> PackageRepository { get; private set; }
    }

}
