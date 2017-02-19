using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace AcademyPackageManager.Tests.Core.PackageInstallerTests.Mocks
{
    internal class PackageInstallerMock : PackageInstaller
    {
        public PackageInstallerMock(IDownloader downloader, IProject project)
            : base(downloader, project)
        {
        }

        public int Counter { get; private set; }

        public override void PerformOperation(IPackage package)
        {
            this.Counter++;
        }
    }
}
