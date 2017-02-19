using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using System;
using System.Linq;

namespace PackageManager.Core
{
    internal class PackageInstaller : IInstaller<IPackage>
    {
        private IDownloader downloader;
        private IProject project;

        public PackageInstaller(IDownloader downloader, IProject project)
        {
            this.downloader = downloader;
            this.project = project;
            this.downloader.Location = project.Location + "\\" + this.BasicFolder;

            this.RestorePackages();
        }

        private void RestorePackages()
        {
            foreach (var package in this.project.PackageRepository.GetAll())
            {
                this.Operation = InstallerOperation.Install;
                this.PerformOperation(package);
            }
        }

        public string BasicFolder
        {
            get
            {
                return "my_modules";
            }
        }

        public InstallerOperation Operation { get; set; }

        public virtual void PerformOperation(IPackage package)
        {
            switch (this.Operation)
            {
                case InstallerOperation.Install:

                    this.project.PackageRepository.Add(package);

                    this.downloader.Remove(package.Name);
                    this.downloader.Download(package.Name);
                    this.downloader.Download(package.Name + "\\" + package.Url);

                    for (int i = 0; i < package.Dependencies.Count; i++)
                    {
                        var packageCurrent = package.Dependencies.ElementAt(i);

                        this.PerformOperation(packageCurrent);
                    }

                    break;

                case InstallerOperation.Uninstall:

                    var isDeleted = this.project.PackageRepository.Delete(package);

                    this.downloader.Remove(package.Name);

                    for (int i = 0; i < package.Dependencies.Count; i++)
                    {
                        var packageCurrent = package.Dependencies.ElementAt(i);

                        this.PerformOperation(packageCurrent);
                    }

                    break;

                case InstallerOperation.Update:
                    var isUpdated = this.project.PackageRepository.Update(package);

                    if (isUpdated)
                    {
                        this.downloader.Remove(package.Name);
                        this.downloader.Download(package.Name);
                        this.downloader.Download(package.Name + "\\" + package.Url);
                    }

                    for (int i = 0; i < package.Dependencies.Count; i++)
                    {
                        var packageCurrent = package.Dependencies.ElementAt(i);

                        this.PerformOperation(packageCurrent);
                    }

                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
