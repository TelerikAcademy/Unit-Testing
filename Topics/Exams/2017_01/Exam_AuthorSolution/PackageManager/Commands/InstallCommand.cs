using System;

using PackageManager.Commands.Contracts;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;

namespace PackageManager.Commands
{
    internal class InstallCommand : ICommand
    {
        private IInstaller<IPackage> installer;
        private IPackage package;

        public InstallCommand(IInstaller<IPackage> installer, IPackage package)
        {
            if (installer == null)
            {
                throw new ArgumentNullException();
            }

            if (package == null)
            {
                throw new ArgumentNullException();
            }

            this.installer = installer;
            this.package = package;
            this.installer.Operation = InstallerOperation.Install;
        }

        protected IInstaller<IPackage> Installer
        {
            get
            {
                return this.installer;
            }
        }

        protected IPackage Package
        {
            get
            {
                return this.package;
            }
        }

        public void Execute()
        {
            this.installer.PerformOperation(this.package);
        }
    }
}
