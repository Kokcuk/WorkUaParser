using System.Net;
using System.Text;

namespace ResumeParser.Common
{
    public class HttpHandler : IHttpHandler
    {
        public string DownloadHttpString(string url)
        {
            string content;
            using (var webClient = new WebClient {Encoding = Encoding.UTF8})
                content = webClient.DownloadString(url);

            return content;
        }
    }
}