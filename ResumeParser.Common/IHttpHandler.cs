namespace ResumeParser.Common
{
    public interface IHttpHandler
    {
        string DownloadHttpString(string url);
    }
}