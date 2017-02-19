using PackageManager.Core.Contracts;
using System;

namespace PackageManager.Core
{
    internal class PackageDownloader : IDownloader
    {
        private IManager saver;

        public PackageDownloader(IManager saver)
        {
            if (saver == null)
            {
                throw new ArgumentNullException();
            }

            this.saver = saver;
        }

        public string Location { get; set; }

        public void Download(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException();
            }

            this.saver.Create(this.Location + "\\" + url);
        }

        public void Remove(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }

            this.saver.Delete(this.Location + "\\" + name);
        }
    }
}
