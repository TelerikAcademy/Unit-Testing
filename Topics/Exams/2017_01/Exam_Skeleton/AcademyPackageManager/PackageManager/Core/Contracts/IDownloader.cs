namespace PackageManager.Core.Contracts
{
    internal interface IDownloader
    {
        string Location { get; set; }

        void Download(string url);

        void Remove(string name);
    }
}
