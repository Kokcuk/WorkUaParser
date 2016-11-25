using ResumeParser.Common.Entities;

namespace ResumeParser.Common
{
    public abstract class ParserBase
    {
        private readonly IHttpHandler httpHandler;

        protected ParserBase(IHttpHandler httpHandler)
        {
            this.httpHandler = httpHandler;
        }

        public abstract Resume Parse(string url);

        protected string DownloadString(string url)
        {
            return this.httpHandler.DownloadHttpString(url);
        }
    }
}