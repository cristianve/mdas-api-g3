namespace Shared.Domain.ValueObject
{
    public class UrlRequest
    {
        public string Url { get; }

        public UrlRequest(string url)
        {
            Url = url;
        }
    }
}
