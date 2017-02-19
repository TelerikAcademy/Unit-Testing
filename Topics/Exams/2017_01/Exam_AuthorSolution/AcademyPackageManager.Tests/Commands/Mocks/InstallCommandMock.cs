using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace AcademyPackageManager.Tests.Commands.Mocks
{
    internal class InstallCommandMock : InstallCommand
    {
        public InstallCommandMock(IInstaller<IPackage> installer, IPackage package)
            : base(installer, package)
        {
        }

        public IInstaller<IPackage> MyInstaller
        {
            get
            {
                return this.Installer;
            }
        }

        public IPackage MyPackage
        {
            get
            {
                return this.Package;
            }
        }
    }
}
